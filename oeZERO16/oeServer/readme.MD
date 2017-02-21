<h1>oeServer</h1><br />
<br />

scénu v UNITY (zatím <b>objZERO</b>) ovládáme z PC/ nebo z mobilu:<br />
http://octopusengine.org/api/zero2.php<br />
<br />
formát JSON dat<br />
<code>{"x": "11" , "y": "22", "z": "33"}</code><br />
na straně serveru dochází ke změnám - klasickým GET requestem... z prohlížeče<br />
klient (UNITY/Csharp) se dotazuje (cca každou vteřinu) a při změně realizuje posun<br />
<br />
seriazable / struct:<br /> 
<code>netData2 tt = JsonUtility.FromJson/netData2/(w2.text);</code><br />
se převádí na vektor<br />
<code>transZERO = new Vector3(tt.x, tt.y, tt.z);</code><br />

<hr />
