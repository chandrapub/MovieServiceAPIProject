using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Drawing;
using System.IO;
using System.Xml;


namespace MovieServiceAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values/5
        public string Get(String id)
        {
            WebClient client = new WebClient();
            string imageurl = string.Empty;
            string ratingResult = string.Empty;
            string apiUrl = $"http://www.omdbapi.com/?t={id}&apikey={TokenClass.token}";
            var result = client.DownloadString(apiUrl);


            File.WriteAllText(HttpContext.Current.Server.MapPath("~/MyFiles/Latestresult.json"), result);

            // A simple example. Treat json as a string
            string[] separatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
            string[] mysplit = result.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);

            if (mysplit[1] != "False")
            {
                for (int i = 0; i < mysplit.Length; i++)
                {
                    if (mysplit[i] == "Poster")
                    {
                        imageurl = mysplit[++i];
                        break;
                    }
                }
            }
            return imageurl;




            //         if (mysplit[1] != "False")
            //            {
            //                //LabelResult.Text = "Ratings : ";
            //                for (int i = 0; i<mysplit.Length; i++)
            //                {
            //                    if (mysplit[i] == "Ratings")
            //                    {
            //                        while (mysplit[++i] == "Source")
            //                        {
            //                            if (mysplit[i - 1] != "Ratings")
            //                            {
            //                                ratingResult += ";";
            //                                //LabelResult.Text += "; ";
            //                                //LabelResult.Text += mysplit[i + 3] + " from " + mysplit[i + 1];
            //                                ratingResult += mysplit[i + 3] + " from " + mysplit[i + 1];

            //                                i = i + 3;
            //                            }
            //}
            //                        break;
            //                    }
            //                }
            //                return ratingResult;
            //            }

            //            else
            //            {
            //                ratingResult = "Movie not found";
            //                //ImagePoster.ImageUrl = "~/MyFiles/SmileyHalo.png";
            //                //LabelResult.Text = "Result";
            //            }            
            //           }
            //        }
            //public string Get(String Rating)
            //{
            //    WebClient client = new WebClient();
            //    string ratingResult = string.Empty;
            //    string apiUrl = $"http://www.omdbapi.com/?t={id}&apikey={TokenClass.token}";
            //    var result = client.DownloadString(apiUrl);


            //    File.WriteAllText(HttpContext.Current.Server.MapPath("~/MyFiles/Latestresult.json"), result);

            //    // A simple example. Treat json as a string
            //    string[] separatingChars = { "\":\"", "\",\"", "\":[{\"", "\"},{\"", "\"}]\"", "{\"", "\"}" };
            //    string[] mysplit = result.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);

            //if (mysplit[1] != "False")
            //{
            //    //LabelResult.Text = "Ratings : ";
            //    for (int i = 0; i < mysplit.Length; i++)
            //    {
            //        if (mysplit[i] == "Ratings")
            //        {
            //            while (mysplit[++i] == "Source")
            //            {
            //                if (mysplit[i - 1] != "Ratings")
            //                {
            //                    ratingResult += ";";
            //                    //LabelResult.Text += "; ";
            //                    //LabelResult.Text += mysplit[i + 3] + " from " + mysplit[i + 1];
            //                    ratingResult += mysplit[i + 3] + " from " + mysplit[i + 1];

            //                    i = i + 3;
            //                }
            //            }
            //            break;
            //        }
            //    }
            //    return ratingResult;
            //}



            //else
            //{
            //    ratingResult = "Movie not found";
            //    //ImagePoster.ImageUrl = "~/MyFiles/SmileyHalo.png";
            //    //LabelResult.Text = "Result";
            //}
        }
    }
}
          
