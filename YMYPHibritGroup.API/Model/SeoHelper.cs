namespace YMYPHibritGroup.API.Model
{
    public class SeoHelper
    {
        public string GetSeoFriendlyUrl(string url)
        {
            //char
            url = url.Replace('ç', 'c');
            url = url.Replace('ö', 'o');

            return url;

        }
    }
}
