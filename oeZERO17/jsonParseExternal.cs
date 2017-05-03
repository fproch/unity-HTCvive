using UnityEngine;
using LitJson;
using System.Net;
using System.Net.Security;
using System;
using System.Security.Cryptography.X509Certificates;
//using Newtonsoft.Json;

public class jsonParseExternal : MonoBehaviour
{

    private string krakenString, bitfinexString, bitstampString;
    private JsonData bitstampBitcoin, krakenAssets, bitfinexBitcoin;
    public bool debugLog = false;

    // Use this for initialization
    void Start()
    {
        //        jsonString1 = @"{""DASH"":{""aclass"":""currency"",""altname"":""DASH"",""decimals"":10,""display_decimals"":5},""GNO"":{""aclass"":""currency"",""altname"":""GNO"",""decimals"":10,""display_decimals"":5},""KFEE"":{""aclass"":""currency"",""altname"":""FEE"",""decimals"":2,""display_decimals"":2},""USDT"":{""aclass"":""currency"",""altname"":""USDT"",""decimals"":8,""display_decimals"":4},""XDAO"":{""aclass"":""currency"",""altname"":""DAO"",""decimals"":10,""display_decimals"":3},""XETC"":{""aclass"":""currency"",""altname"":""ETC"",""decimals"":10,""display_decimals"":5},""XETH"":{""aclass"":""currency"",""altname"":""ETH"",""decimals"":10,""display_decimals"":5},""XICN"":{""aclass"":""currency"",""altname"":""ICN"",""decimals"":10,""display_decimals"":5},""XLTC"":{""aclass"":""currency"",""altname"":""LTC"",""decimals"":10,""display_decimals"":5},""XMLN"":{""aclass"":""currency"",""altname"":""MLN"",""decimals"":10,""display_decimals"":5},""XNMC"":{""aclass"":""currency"",""altname"":""NMC"",""decimals"":10,""display_decimals"":5},""XREP"":{""aclass"":""currency"",""altname"":""REP"",""decimals"":10,""display_decimals"":5},""XXBT"":{""aclass"":""currency"",""altname"":""XBT"",""decimals"":10,""display_decimals"":5},""XXDG"":{""aclass"":""currency"",""altname"":""XDG"",""decimals"":8,""display_decimals"":2},""XXLM"":{""aclass"":""currency"",""altname"":""XLM"",""decimals"":8,""display_decimals"":5},""XXMR"":{""aclass"":""currency"",""altname"":""XMR"",""decimals"":10,""display_decimals"":5},""XXRP"":{""aclass"":""currency"",""altname"":""XRP"",""decimals"":8,""display_decimals"":5},""XXVN"":{""aclass"":""currency"",""altname"":""XVN"",""decimals"":4,""display_decimals"":2},""XZEC"":{""aclass"":""currency"",""altname"":""ZEC"",""decimals"":10,""display_decimals"":5},""ZCAD"":{""aclass"":""currency"",""altname"":""CAD"",""decimals"":4,""display_decimals"":2},""ZEUR"":{""aclass"":""currency"",""altname"":""EUR"",""decimals"":4,""display_decimals"":2},""ZGBP"":{""aclass"":""currency"",""altname"":""GBP"",""decimals"":4,""display_decimals"":2},""ZJPY"":{""aclass"":""currency"",""altname"":""JPY"",""decimals"":2,""display_decimals"":0},""ZKRW"":{""aclass"":""currency"",""altname"":""KRW"",""decimals"":2,""display_decimals"":0},""ZUSD"":{""aclass"":""currency"",""altname"":""USD"",""decimals"":4,""display_decimals"":2}}";
        //        jsonString = @"{""mid"":""1427.5"",""bid"":""1426.9"",""ask"":""1428.1"",""last_price"":""1428.3"",""low"":""1393.5"",""high"":""1439.5"",""volume"":""10014.11690992"",
        //""timestamp"":""1493504302.748758996""}";
        //        Debug.Log(jsonString);
        //        Debug.Log(jsonString1);

        using (WebClient wc = new WebClient())
        {
            ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
            string krakenURL = "https://api.kraken.com/0/public/Assets";
            ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
            string bitfinexURL = "https://api.bitfinex.com/v1/pubticker/BTCUSD";

            string bitstampURL = "https://www.bitstamp.net/api/ticker";

            //--------------------------------------------------------------
            // Bitfinex bitcoin
            bitfinexString = wc.DownloadString(bitfinexURL);
            bitfinexBitcoin = JsonMapper.ToObject(bitfinexString);
            if (debugLog) Debug.Log("*** bitfinexString: ***" + bitfinexString);
            Debug.Log(bitfinexBitcoin["last_price"]);//["altname"]);

            //--------------------------------------------------------------
            // Kraken Assets
            krakenString = wc.DownloadString(krakenURL);
            if (debugLog) Debug.Log("***krakenString: ***" + krakenString);
            krakenAssets = JsonMapper.ToObject(krakenString);
            //Debug.Log(krakenAssets["result"]["GNO"]["mid"]);//["altname"]);
            Debug.Log(krakenAssets["result"]["XLTC"]["altname"]);//["altname"]);

            //Debug.Log(krakenAssets["result"]["BTC"]["last_price"]);//["altname"]);
            //Debug.Log(krakenAssets["result"]["LTC"]["last_price"]);//["altname"]);
            //Debug.Log(krakenAssets["result"]["DASH"]["last_price"]);//["altname"]);

            //--------------------------------------------------------------
            // bitstamp Bitcoin
            bitstampString = wc.DownloadString(bitstampURL);
            bitstampBitcoin = JsonMapper.ToObject(bitstampString);
            if (debugLog) Debug.Log("*** bitstampString: ***" + bitstampString);
            Debug.Log(bitstampBitcoin["last"]);



        }


    }



    // Update is called once per frame
    void Update()
    {

    }

    public bool MyRemoteCertificateValidationCallback(System.Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        bool isOk = true;
        // If there are errors in the certificate chain, look at each error to determine the cause.
        if (sslPolicyErrors != SslPolicyErrors.None)
        {
            for (int i = 0; i < chain.ChainStatus.Length; i++)
            {
                if (chain.ChainStatus[i].Status != X509ChainStatusFlags.RevocationStatusUnknown)
                {
                    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                    bool chainIsValid = chain.Build((X509Certificate2)certificate);
                    if (!chainIsValid)
                    {
                        isOk = false;
                    }
                }
            }
        }
        return isOk;
    }
}