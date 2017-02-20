<?php  
//octopusengine.org (c) 2016
//-----------------
//simple test - web server / json file / unity ZEROobj mobile control

$t = $_GET['t'];

$fName =  "zero2.json"; 
$file = fopen($fName, "r") or die("can't open file");  
$json = fread($file,filesize($fName)); 
$jsonParse = json_decode($json);
$tx = $jsonParse->x;
$ty = $jsonParse->y;
$tz = $jsonParse->z;

if($t == "xplus") {  
  $tx++;
  $tojson = '{"x": "'.$tx.'","y": "'.$ty.'","z": "'.$tz.'"}';
  saveJson($fName,$tojson);
} 
else if ($t == "xminus") {
  $tx--; 
  $tojson = '{"x": "'.$tx.'","y": "'.$ty.'","z": "'.$tz.'"}';
  saveJson($fName,$tojson);
}
else if ($t == "yplus") {
  $ty++; 
  $tojson = '{"x": "'.$tx.'","y": "'.$ty.'","z": "'.$tz.'"}';
  saveJson($fName,$tojson);
}
else if ($t == "yminus") {
  $ty--; 
  $tojson = '{"x": "'.$tx.'","y": "'.$ty.'","z": "'.$tz.'"}';
  saveJson($fName,$tojson);
}
else if ($t == "zplus") {
  $tz++; 
  $tojson = '{"x": "'.$tx.'","y": "'.$ty.'","z": "'.$tz.'"}';
  saveJson($fName,$tojson);
}
else if ($t == "zminus") {
  $tz--; 
  $tojson = '{"x": "'.$tx.'","y": "'.$ty.'","z": "'.$tz.'"}';
  saveJson($fName,$tojson);
  
}

function saveJson($fName,$jsonF)
{ 
  $file = fopen($fName, "w") or die("can't open file");
  fwrite($file, $jsonF);
  fclose($file);
} 

?>

<html>  
  <head>      
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>oeServer - ZERO2</title>

    <script src="https://code.jquery.com/jquery-2.1.4.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css">

  </head>
  <body>
<h2>simple test - web server / json file / unity ZEROobj mobile control
</h2>
    <div class="row" style="margin-top: 20px;">
      <div class="col-md-8 col-md-offset-2">
        <a href="?t=xplus" class="btn btn-success btn-block btn-lg">X Plus</a>
        <br />
        <a href="?t=xminus" class="led btn btn-danger btn-block btn-lg">X Minus</a>
        <br />
        
        <a href="?t=yplus" class="btn btn-success btn-block btn-lg">Y Plus</a>
        <br />
        <a href="?t=yminus" class="led btn btn-danger btn-block btn-lg">Y Minus</a>
        <br />
        
        <a href="?t=zplus" class="btn btn-success btn-block btn-lg">Z Plus</a>
        <br />
        <a href="?t=zminus" class="led btn btn-danger btn-block btn-lg">Z Minus</a>
        <br />
                
        <div class="light-status well" style="margin-top: 5px; text-align:center">
          <?php
            $file = fopen($fName, "r") or die("can't open file");  
            $json = fread($file,filesize($fName)); 
            $jsonParse = json_decode($json);

            $tx = $jsonParse->x;
            $ty = $jsonParse->y;
            $tz = $jsonParse->z;
              
            echo $tx." / ".$ty." / ".$tz." / "; 

          ?>
        </div>
      </div>
    </div>

<hr />
octopusengine.org (2016)
  </body>
</html> 