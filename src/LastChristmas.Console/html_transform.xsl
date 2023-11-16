<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="ArrayOfRanking[count(Ranking[Rank = 1]) > 0]">
<html lang="en">
<head>
  <meta charset="utf-8"/>
  <title>Last Christmas has hit number one!</title>
  <meta name="description" content="Wham Watchdog making sure you know when Last Christmas tops the charts"/>
  <meta name="author" content="m. james harmon michael harmon"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link href="//fonts.googleapis.com/css?family=Raleway:400,300,600" rel="stylesheet" type="text/css"/>
  <link rel="stylesheet" href="assets/css/normalize.css"/>
  <link rel="stylesheet" href="assets/css/skeleton.css"/>
  <link rel="icon" type="image/png" href="images/favicon.png"/>
</head>
<body>

  <div class="container">
    <div class="row">
      <div class="one-half column" style="margin-top: 25%">
        <h4>Last Christmas is Back on Top!</h4>
        <p>🎉 Last Christmas by Wham! is atop the charts again.  Celebrate with a dance and another listen.</p>
        <a href="https://youtu.be/E8gmARGvPlI?si=gt_S_mTrTcC_GmCa"><img src="assets/img/last_christmas.jpeg" width="400" height="400" /></a>
      </div>
    </div>
  </div>
</body>
</html>

</xsl:template>

<xsl:template match="ArrayOfRanking[count(Ranking[Rank = 1]) = 0]">
<html lang="en">
<head>
  <meta charset="utf-8"/>
  <title>Last Christmas is Not Number 1</title>
  <meta name="description" content="Wham Watchdog making sure you know when Last Christmas tops the charts"/>
  <meta name="author" content="m. james harmon michael harmon"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <link href="//fonts.googleapis.com/css?family=Raleway:400,300,600" rel="stylesheet" type="text/css"/>
  <link rel="stylesheet" href="assets/css/normalize.css"/>
  <link rel="stylesheet" href="assets/css/skeleton.css"/>
  <link rel="icon" type="image/png" href="images/favicon.png"/>
</head>
<body>

  <div class="container">
    <div class="row">
      <div class="one-half column" style="margin-top: 25%">
         <h4>Oops, Something Else is On Top! 😢</h4>
    <p>Seems like Last Christmas is taking a break from the charts. No worries, though! It's always winner in our hearts and there is no shame in giving a click and listen 🎄🎶</p>
        <a href="https://youtu.be/E8gmARGvPlI?si=gt_S_mTrTcC_GmCa"><img src="assets/img/last_christmas.jpeg" width="400" height="400" /></a>
      </div>
    </div>
  </div>
</body>
</html>
</xsl:template>
</xsl:stylesheet>
