using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace RiotAPI
{
    public class Champion
    {
        public int id { get; set;}
        public bool active { get; set; }
        public bool botEnabled { get; set; }
        public bool freeToPlay { get; set; }
        public bool botMmEnabled { get; set; }
        public bool rankedPlayEnabled { get; set; }
    }

    public class ChampionList
    {
        public List<Champion> champions { get; set; }
    }

    public class FellowPlayer
    {
        public int championId { get; set; }
        public int teamId { get; set; }
        public int summonerId { get; set; }
    }

    public class Stats
    {
        public int totalDamageDealtToChampions { get; set; }
        public int item2 { get; set; }
        public int goldEarned { get; set; }
        public int item1 { get; set; }
        public int wardPlaced { get; set; }
        public int totalDamageTaken { get; set; }
        public int physicalDamageDealtPlayer { get; set; }
        public int killingSprees { get; set; }
        public int totalUnitsHealed { get; set; }
        public int largestCriticalStrike { get; set; }
        public int level { get; set; }
        public int doubleKills { get; set; }
        public int tripleKills { get; set; }
        public int magicDamageDealtToChampions { get; set; }
        public int magicDamageDealtPlayer { get; set; }
        public int assists { get; set; }
        public int magicDamageTaken { get; set; }
        public int numDeaths { get; set; }
        public int totalTimeCrowdControlDealt { get; set; }
        public int largestMultiKill { get; set; }
        public int physicalDamageTaken { get; set; }
        public int team { get; set; }
        public bool win { get; set; }
        public int totalDamageDealt { get; set; }
        public int largestKillingSpree { get; set; }
        public int totalHeal { get; set; }
        public int item4 { get; set; }
        public int item3 { get; set; }
        public int item5 { get; set; }
        public int minionsKilled { get; set; }
        public int timePlayed { get; set; }
        public int physicalDamageDealtToChampions { get; set; }
        public int championsKilled { get; set; }
        public int goldSpent { get; set; }
        public int? item0 { get; set; }
        public int? trueDamageTaken { get; set; }
        public int? trueDamageDealtPlayer { get; set; }
        public int? trueDamageDealtToChampions { get; set; }
        public int? neutralMinionsKilledYourJungle { get; set; }
        public int? sightWardsBought { get; set; }
        public int? item6 { get; set; }
        public int? neutralMinionsKilled { get; set; }
        public int? turretsKilled { get; set; }
        public int? neutralMinionsKilledEnemyJungle { get; set; }
        public int? wardKilled { get; set; }
        public int? barracksKilled { get; set; }
    }

    public class Game
    {
        public List<FellowPlayer> fellowPlayers { get; set; }
        public string gameType { get; set; }
        public Stats stats { get; set; }
        public int gameId { get; set; }
        public int ipEarned { get; set; }
        public int spell1 { get; set; }
        public int teamId { get; set; }
        public int spell2 { get; set; }
        public string gameMode { get; set; }
        public int mapId { get; set; }
        public int level { get; set; }
        public bool invalid { get; set; }
        public string subType { get; set; }
        public object createDate { get; set; }
        public int championId { get; set; }
    }

    public class RecentGames
    {
        public List<Game> games { get; set; }
        public int summonerId { get; set; }
    }

    public class MiniSeries
    {
        public string progress { get; set; }
        public int target { get; set; }
        public int losses { get; set; }
        public int wins { get; set; }
    }

    public class Entry
    {
        public int leaguePoints { get; set; }
        public bool isFreshBlood { get; set; }
        public bool isHotStreak { get; set; }
        public string division { get; set; }
        public bool isInactive { get; set; }
        public bool isVeteran { get; set; }
        public string playerOrTeamName { get; set; }
        public string playerOrTeamId { get; set; }
        public int wins { get; set; }
        public MiniSeries miniSeries { get; set; }
    }

    public class League
    {
        public string queue { get; set; }
        public string name { get; set; }
        public string participantId { get; set; }
        public List<Entry> entries { get; set; }
        public string tier { get; set; }
    }

    public class Leagues
    {
        public List<League> league { get; set; }
    }

    class RiotAPI
    {
        private string key;
        private string userAgent;
        private int blockTime;

        public string Key { get { return key; } }
        public string UserAgent { get { return userAgent; } }
        public int BlockTime { get { return blockTime; } }

        public sealed static class GameTypes
        {
            public string NONE { get { return "NONE"; } }
            public string NORMAL { get { return "NORMAL"; } }
            public string NORMAL_3x3 { get { return "NORMAL_3x3"; } }
            public string ODIN_UNRANKED { get { return "ODIN_UNRANKED"; } }
            public string ARAM_UNRANKED_5x5 { get { return "ARAM_UNRANKED_5x5"; } }
            public string BOT { get { return "BOT"; } }
            public string BOT_3x3 { get { return "BOT_3x3"; } }
            public string RANKED_SOLO_5x5 { get { return "RANKED_SOLO_5x5"; } }
            public string RANKED_TEAM_3x3 { get { return "RANKED_TEAM_3x3"; } }
            public string RANKED_TEAM_5x5 { get { return "RANKED_TEAM_5x5"; } }
            public string ONEFORALL_5x5 { get { return "ONEFORALL_5x5"; } }
            public string FIRSTBLOOD_1x1 { get { return "FIRSTBLOOD_1x1"; } }
            public string FIRSTBLOOD_2x2 { get { return "FIRSTBLOOD_2x2"; } }
            public string SR_6x6 { get { return "SR_6x6"; } }
            public string CAP_5x5 { get { return "CAP_5x5"; } }
            public string URF { get { return "URF"; } }
            public string URF_BOT { get { return "URF_BOT"; } }
        }

        public RiotAPI(string Key, string UserAgent)
        {
            userAgent = UserAgent;
            key = Key;
            blockTime = 0;
        }

        public RiotAPI(string Key, string UserAgent, int BlockTime)
        {
            userAgent = UserAgent;
            key = Key;
            blockTime = BlockTime;
        }

        private string RetrieveJSON(string URL)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream stream = null;
            string JSON = "";

        retry:
            request = (HttpWebRequest)HttpWebRequest.Create(URL + "api_key=" + key);
            request.ContentType = "text/html; charset=UTF-8";
            request.Method = "GET"; 
            request.UserAgent = userAgent;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                HttpWebResponse repo = (HttpWebResponse)e.Response;
                if ((int)repo.StatusCode == 429)
                {
                    System.Threading.Thread.Sleep(blockTime);
                    Console.WriteLine("Blocking");
                    goto retry;
                }
            }
            stream = response.GetResponseStream();

            JSON = new StreamReader(stream, Encoding.UTF8).ReadToEnd();
            return JSON;
        }

        public ChampionList GetChampionList(string Region)
        {
            return JsonConvert.DeserializeObject<ChampionList>(RetrieveJSON("https://prod.api.pvp.net/api/lol/"+Region+"/v1.2/champion?"));
        }

        public Champion GetChampion(string Region, int ChampionId)
        {
            return JsonConvert.DeserializeObject<Champion>(RetrieveJSON("https://prod.api.pvp.net/api/lol/" + Region + "/v1.2/champion/" + ChampionId.ToString() + "?"));
        }

        public RecentGames GetRecentGames(string Region, int SummonerId)
        {
            return JsonConvert.DeserializeObject<RecentGames>(RetrieveJSON("https://prod.api.pvp.net/api/lol/" + Region + "/v1.3/game/by-summoner/" + SummonerId.ToString() + "/recent?"));
        }

        public Leagues GetSummonerLeagues(string Region, int SummonerId)
        {
            string JSON = RetrieveJSON("https://prod.api.pvp.net/api/lol/" + Region + "/v2.4/league/by-summoner/" + SummonerId.ToString() + "?");
            int pos = JSON.IndexOf(SummonerId.ToString());
            if (pos >= 0)
                JSON = JSON.Substring(0, pos) + "league" + JSON.Substring(pos + SummonerId.ToString().Length);
            return JsonConvert.DeserializeObject<Leagues>(JSON);
        }

        public Leagues GetSummonerLeagueEntries(string Region, int SummonerId)
        {
            string JSON = RetrieveJSON("https://prod.api.pvp.net/api/lol/" + Region + "/v2.4/league/by-summoner/" + SummonerId.ToString() + "/entry?");
            int pos = JSON.IndexOf(SummonerId.ToString());
            if (pos >= 0)
                JSON = JSON.Substring(0, pos) + "league" + JSON.Substring(pos + SummonerId.ToString().Length);
            return JsonConvert.DeserializeObject<Leagues>(JSON);
        }

        public Leagues GetTeamLeagues(string Region, int TeamId)
        {
            string JSON = RetrieveJSON("https://prod.api.pvp.net/api/lol/" + Region + "/v2.4/league/by-team/" + TeamId.ToString() + "?");
            int pos = JSON.IndexOf(TeamId.ToString());
            if (pos >= 0)
                JSON = JSON.Substring(0, pos) + "league" + JSON.Substring(pos + TeamId.ToString().Length);
            return JsonConvert.DeserializeObject<Leagues>(JSON);
        }

        public Leagues GetTeamLeagueEntries(string Region, int TeamId)
        {
            string JSON = RetrieveJSON("https://prod.api.pvp.net/api/lol/" + Region + "/v2.4/league/by-team/" + TeamId.ToString() + "/entry?");
            int pos = JSON.IndexOf(TeamId.ToString());
            if (pos >= 0)
                JSON = JSON.Substring(0, pos) + "league" + JSON.Substring(pos + TeamId.ToString().Length);
            return JsonConvert.DeserializeObject<Leagues>(JSON);
        }

        public League GetChallenger(string Region, string queue)
        {
            string JSON = RetrieveJSON("https://prod.api.pvp.net/api/lol/" + Region + "/v2.4/league/challenger?type=" + queue + "&");
            return JsonConvert.DeserializeObject<League>(JSON);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RiotAPI Riot = new RiotAPI("2a7d0445-b201-4269-b6b5-74304b468631","Test",100);
            Leagues list = Riot.GetSummonerLeagueEntries("na", 20873839);
            while (true)
            {
                list = Riot.GetSummonerLeagueEntries("na", 20873839);
                Console.WriteLine("lol");
            }
            Console.ReadLine();
        }
    }
}
