<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template name="common-html">
    <html lang="en">
        <head>
            <meta charset="utf-8"/>
            <title><xsl:value-of select="@title"/></title>
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
                        <h4><xsl:value-of select="@announcement"/></h4>
                        <p><xsl:value-of select="@description"/></p>
                        <a href="https://youtu.be/E8gmARGvPlI?si=gt_S_mTrTcC_GmCa"><img src="assets/img/last_christmas.jpeg" width="400" height="400" /></a>
                    </div>
                </div>
            </div>
        </body>
    </html>
</xsl:template>

<xsl:template match="ArrayOfRanking[count(Ranking[Rank = 1]) > 0]">
    <xsl:call-template name="common-html">
        <xsl:with-param name="title" select="Is 'Last Christmas' #1? YES!!" />
        <xsl:with-param name="announcement" select="Last Christmas is Back on Top!" />
        <xsl:with-param name="description" select="🎉 Last Christmas by Wham! is atop the charts again.  Celebrate with a dance and another listen." />
    </xsl:call-template>
 </xsl:template>

<xsl:template match="ArrayOfRanking[count(Ranking[Rank = 1]) = 0]">
     <xsl:call-template name="common-html">
        <xsl:with-param name="title" select="Is 'Last Christmas' #1? No!" />
        <xsl:with-param name="announcement" select="Oops, Something Else is On Top! 😢" />
        <xsl:with-param name="description" select="Seems like Last Christmas is taking a break from the charts. No worries, though! It's always winner in our hearts and there is no shame in giving a click and listen 🎄🎶" />
    </xsl:call-template>

</xsl:template>
</xsl:stylesheet>
