# CitySearch
CitySearch is a C# class library created to utilize the Google Place AutoComplete API, to provide a result of predicted input, as a C# object, based upon a search string parameter.

# Instructions:
To use the class library, import it into your project, add your dependencies, then:

1. Generate an API-key, and create an APIKey object, feeding your own API-key as a string as a parameter into the constructor. 
2. Create a CityFinder object; pass the APIKey above in as a parameter.
3. To Retrieve results, call upon finder.Search('searchString');, replacing 'searchString' with either a fixed term, or to dynamically use    within a program rather than test, apply your own implementation as you see fit.

# Links:
https://developers.google.com/places/web-service/autocomplete
http://www.benhayward.net

# Contact Me:
benhayward.ben@gmail.com
