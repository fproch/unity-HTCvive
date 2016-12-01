 private IEnumerator BTC()
    {
        WWW w = new WWW("https://www.bitstamp.net/api/ticker");
        yield return w;
        //toRet = "NIC";
        if (w.error != null)
        {
            Debug.Log("Error .. " + w.error);
            // for example, often 'Error .. 404 Not Found'
        }
        else
        {
            Debug.Log("Found ... ==>" + w.text + "<==");           
        }

        //public JSONNode btcData;

        var jsonBTC = w.text;//System.IO.File.ReadAllText(@"d:\unity-temp-data/test.json");
                             //btcData = ProcessInboundData(jsonBTC);

        //var kBTC = JsonUtility.FromJson<object>(jsonBTC); //["last"];
        var kBTC = JsonUtility.FromJson<Info[]>(jsonBTC);
        Debug.Log("BTC::: " + kBTC[0].ToString());


        //var objects = JArray.Parse(jsonBTC); // parse as array 
        //myObject = JsonUtility.FromJson(jsonBTC);
        //List<Item> items = JsonConvert.DeserializeObject<List<Item>>(jsonBTC);
        //Debug.Log("BTC::: " + items);

        //example code to separate all that text in to lines:
        //longStringFromFile = w.text
        //List<string> lines = new List<string>(longStringFromFile.Split(new string[] { "\r","\n" }, StringSplitOptions.RemoveEmptyEntries) );
        // remove comment lines...
        //lines = lines.Where(line => !(line.StartsWith("//") || line.StartsWith("#"))).ToList();

        //return toRet;

    }