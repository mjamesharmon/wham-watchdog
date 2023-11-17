<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="ArrayOfRanking[count(Ranking[Rank = 1]) > 0]">
<xsl:call-template name="common_md" >
<xsl:with-param name="announcement">Last Christmas is Back on Top!
</xsl:with-param>
<xsl:with-param name="description">🎉 Last Christmas by Wham! is atop the charts again.  Celebrate with a dance and another listen.</xsl:with-param>
</xsl:call-template>
</xsl:template>

<xsl:template match="ArrayOfRanking[count(Ranking[Rank = 1]) = 0]">
<xsl:call-template name="common_md" >
<xsl:with-param name="announcement">Oops, Something Else is On Top! 😢
</xsl:with-param>
<xsl:with-param name="description">Seems like Last Christmas is taking a break from the charts. No worries, though! It's always winner in our hearts and there is no shame in giving a click and listen 🎄🎶</xsl:with-param>
</xsl:call-template>
</xsl:template>

<xsl:template name="common_md">
<xsl:param name="announcement" />
<xsl:param name="description" />
#### <xsl:value-of select="$announcement"/>
<xsl:value-of select="$description"/>
[![Click me](https://github.com/mjamesharmon/wham-watchdog/blob/main/docs/assets/img/last_christmas.jpeg?raw=true "Last Christmas")]("https://youtu.be/E8gmARGvPlI?si=gt_S_mTrTcC_GmCa")
</xsl:template>
</xsl:stylesheet>