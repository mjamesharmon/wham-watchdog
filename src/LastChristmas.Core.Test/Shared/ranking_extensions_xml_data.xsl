<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
  <html>
  <body>
    <h2>Rankings</h2>
    <table border="1">
      <tr bgcolor="#9acd32">
        <th>Country</th>
        <th>Rank</th>
      </tr>
      <xsl:for-each select="ArrayOfRanking/Ranking">
        <tr>
          <td><xsl:value-of select="Country"/></td>
          <td><xsl:value-of select="Rank"/></td>
        </tr>
      </xsl:for-each>
    </table>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>