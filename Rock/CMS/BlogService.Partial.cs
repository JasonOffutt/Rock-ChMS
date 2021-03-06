﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System.Linq;
using System.Text;
using System.Xml;

namespace Rock.CMS
{
    public partial class BlogService: Rock.Data.IFeed
    {
        /// <summary>
        /// Returns the feed.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="count">The count.</param>
        /// <param name="format">The format.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <returns></returns>
        public string ReturnFeed( int key, int count, string format, out string errorMessage, out string contentType )
        {
            errorMessage = string.Empty;
            contentType = "application/rss+xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;

            StringBuilder builder = new StringBuilder();

            using ( XmlWriter writer = XmlWriter.Create( builder, settings ) )
            {
                // get blog
                Blog blog = this.Get( key );

                if ( blog == null )
                {
                    errorMessage = "The blog with the id of " + key.ToString() + " could not be found.";
                }
                else
                {
                    writer.WriteStartDocument();

                    // write rss Tags
                    writer.WriteStartElement( "rss" );
                    writer.WriteAttributeString( "version", "2.0" );

                    writer.WriteStartElement( "channel" );
                    writer.WriteElementString( "title", blog.Name );
                    writer.WriteElementString( "link", blog.PublicPublishingPoint );
                    writer.WriteElementString( "description", blog.Description );
                    writer.WriteElementString( "copyright", blog.CopyrightStatement );

                    // get posts
                    var blogPosts = blog.BlogPosts.Take( count );

                    foreach ( BlogPost post in blogPosts )
                    {
                        writer.WriteStartElement( "item" );
                        writer.WriteElementString( "title", post.Title );
                        writer.WriteElementString( "description", post.Content );
                        writer.WriteElementString( "link", "" );
                        writer.WriteElementString( "pubDate", post.PublishDate.ToString() );
                        writer.WriteEndElement();
                    }

                    //  close up tags
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                writer.Flush();
                writer.Close();

            }
            return builder.ToString();
        }
    }
}
