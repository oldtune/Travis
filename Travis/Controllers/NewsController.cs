using HtmlAgilityPack;
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
using System.Web;

namespace Travis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        FetchOptions _fetchOptions;
        public NewsController(IOptionsSnapshot<FetchOptions> fetchOptions)
        {
            _fetchOptions = fetchOptions.Value;
        }

        [HttpGet("")]
        public async Task<IActionResult> Fetch()
        {
            var htmlWeb = new HtmlWeb();
            var tasks = _fetchOptions.Sites.Select(site => htmlWeb.LoadFromWebAsync(site));
            var htmlDocs = await Task.WhenAll<HtmlDocument>(tasks);
            var wordGroups = htmlDocs.AsParallel().SelectMany(doc => doc.DocumentNode.Descendants("a"))
                .Select(tag => HttpUtility.HtmlDecode(tag.InnerText).Trim())
                .SelectMany(phrase => phrase.Split(' '))
                .Where(word => !string.IsNullOrWhiteSpace(word))
                .GroupBy(word => word, StringComparer.InvariantCultureIgnoreCase)
                .Select(wordGroup => new { Word = wordGroup.Key, Count = wordGroup.Count() })
                .OrderByDescending(wordCountPair => wordCountPair.Count)
                .Take(20)
                .ToList();
            return Ok(wordGroups);
        }
    }
}
