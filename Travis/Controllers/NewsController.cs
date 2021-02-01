using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sharedkernel.Configs;
using Sharedkernel.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Travis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        IHttpClientFactory _httpClientFactory;
        FetchOptions _fetchOptions;
        public NewsController(IHttpClientFactory httpClientFactory, IOptionsSnapshot<FetchOptions> fetchOptions)
        {
            _httpClientFactory = httpClientFactory;
            _fetchOptions = fetchOptions.Value;
        }

        [HttpGet("")]
        public async Task<IActionResult> Fetch()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            var tasks = _fetchOptions.Sites.Select(site => ExtractFromSite(httpClient, site));

            var titlesOfPages = await Task.WhenAll(tasks);
            var everyTitles = titlesOfPages.SelectMany(titles => titles);
            return Ok(everyTitles);
        }

        private async Task<string> GetSiteContent(HttpClient httpClient, string site)
        {
            var streamContent = await httpClient.GetStreamAsync(site);

            var streamReader = new StreamReader(streamContent, Encoding.UTF8);
            return await streamReader.ReadToEndAsync();
        }

        private async Task<List<string>> ExtractFromSite(HttpClient httpClient, string site)
        {
            string content = await GetSiteContent(httpClient, site);
            //the regex is being hardcoded
            Regex regex = new Regex(@"<a(?=\s|>)[^>]*>(?<content>.+?)<\/a>", RegexOptions.Compiled);

            MatchCollection matches = regex.Matches(content);

            //this one too, should be dynamic
            Func<Match, string> extractor = (match) => (match.Groups["content"].Value);

            return matches.AsParallel().Select(match => extractor(match)).ToList();
        }

        [HttpGet("force-get")]
        public IActionResult ForceFetch()
        {
            return Ok();
        }
    }
}
