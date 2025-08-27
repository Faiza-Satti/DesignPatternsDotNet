using Observer.Core;

var agency = new NewsAgency();

var sports = new SportsSubscriber();
var weather = new WeatherSubscriber();

agency.Attach(sports);
agency.Attach(weather);

agency.Notify("Breaking Sports News: Team A won!");
agency.Notify("Weather Update: Heavy rain expected.");