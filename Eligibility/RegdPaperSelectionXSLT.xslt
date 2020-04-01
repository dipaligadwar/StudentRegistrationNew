<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="MyNamespace" exclude-result-prefixes="asp">
  <xsl:output method="html" encoding="utf-8"/>
  <xsl:template match="Course">
    <xsl:apply-templates mode="output" select="Group"/>
    <xsl:for-each select="Group">
      <xsl:apply-templates mode="output" select="Paper"/>
    </xsl:for-each>
    <xsl:apply-templates/>
  </xsl:template>

  <xsl:template match="Group">
    <xsl:if test="name(parent::node()) != 'Course'">
      <table>
        <xsl:attribute name="width">100%</xsl:attribute>
        <tr>
          <td>
            <xsl:attribute name="width">5%</xsl:attribute>
          </td>
          <td>
            <xsl:attribute name="width">95%</xsl:attribute>
            <xsl:attribute name="ID">TDGroup<xsl:value-of select="@ID"/></xsl:attribute>
            <label>
              <xsl:attribute name="ID">Group<xsl:value-of select="@ID"/></xsl:attribute>
              <xsl:value-of select="@Name"/>
              <FONT color="Red">
                Select Minimum: <xsl:value-of select="@Min"/>
              </FONT>
              <FONT color="Green">
                Maximum: <xsl:value-of select="@Max"/> [If Applicable]
              </FONT>
            </label>
            <xsl:apply-templates></xsl:apply-templates>
          </td>
        </tr>
      </table>
    </xsl:if>

    <xsl:if test="name(parent::node()) = 'Course'">
      <fieldset>
        <xsl:attribute name="width">95%</xsl:attribute>
        <Legend>
          <label>
            <xsl:attribute name="ID">PGroup<xsl:value-of select="@ID"/></xsl:attribute>
            <xsl:value-of select="@Name"/>
            <FONT color="Red">
              Select Minimum:<xsl:value-of select="@Min"/>
            </FONT>
            <FONT color="Green">
              Maximum: <xsl:value-of select="@Max"/> [If Applicable]
            </FONT>
          </label>
        </Legend>
        <table>
          <xsl:attribute name="width">100%</xsl:attribute>
          <tr>
            <td></td>
            <td>
              <xsl:attribute name="ID">TDGroup<xsl:value-of select="@ID"/></xsl:attribute>
              <xsl:apply-templates/>
            </td>
          </tr>
        </table>
      </fieldset>
    </xsl:if>
  </xsl:template>
  <!--
      //
			// Added By : Rupam 
			// Date     : 3 May 2008
			//
  -->
  <xsl:template match="PaperHead">
    <table>
      <xsl:attribute name="width">100%</xsl:attribute>
      <tr>
        <td>
          <xsl:attribute name="width">5%</xsl:attribute>
        </td>
        <td>
          <xsl:attribute name="width">95%</xsl:attribute>
          <xsl:attribute name="onclick">return ValidateMaxLimit(document.getElementById('<xsl:value-of select="@ID" />_<xsl:for-each select="child::node()"><xsl:value-of select="@ID" /><xsl:if test="position() != last()"><xsl:text>_</xsl:text></xsl:if></xsl:for-each>'),'<xsl:value-of select="@GroupID"/>',this,event);</xsl:attribute>
          <!-- Pelase DO NOT change the sequence -->
          <xsl:attribute name="ID"><xsl:value-of select="@GroupID"/>__<xsl:value-of select="@GroupName"/>__<xsl:value-of select="@GMinLimit"/>__<xsl:value-of select="@GMaxLimit"/>__<xsl:value-of select="@GParentID"/>__<xsl:value-of select="@GParentName"/>__<xsl:value-of select="@GParentMinLimit"/>__<xsl:value-of select="@GParentMaxLimit"/>__<xsl:value-of select="@TopMostGroupID"/>__<xsl:value-of select="@TMGName"/>__<xsl:value-of select="@TMGMinLimit"/>__<xsl:value-of select="@TMGMaxLimit"/>__<xsl:value-of select="@ID"/></xsl:attribute>
          <INPUT>
            <xsl:attribute name="TYPE">checkbox</xsl:attribute>
            <xsl:attribute name="ID"><xsl:value-of select="@ID" />_<xsl:for-each select="child::node()"><xsl:value-of select="@ID" /><xsl:if test="position() != last()"><xsl:text>_</xsl:text></xsl:if></xsl:for-each></xsl:attribute>
            <xsl:attribute name="value"><xsl:value-of select="@value" />_<xsl:for-each select="child::node()"><xsl:value-of select="@abbr" /><xsl:if test="position() != last()"><xsl:text>_</xsl:text></xsl:if></xsl:for-each></xsl:attribute>
            <xsl:attribute name="class"><xsl:for-each select="child::node()">chk<xsl:value-of select="@PpID" /><xsl:if test="position() != last()"><xsl:text>_</xsl:text></xsl:if></xsl:for-each></xsl:attribute>
            <xsl:attribute name="title"><xsl:value-of select="@Name"/></xsl:attribute>
            <xsl:if test="@Checked='checked'">
             <xsl:attribute name="checked">checked</xsl:attribute>
            </xsl:if>
            <!--<script>
              changeBackgroundColor('<xsl:value-of select="@GroupID"/>','<xsl:value-of select="@GroupID"/>__<xsl:value-of select="@GroupName"/>__<xsl:value-of select="@GMinLimit"/>__<xsl:value-of select="@GMaxLimit"/>__<xsl:value-of select="@GParentID"/>__<xsl:value-of select="@GParentName"/>__<xsl:value-of select="@GParentMinLimit"/>__<xsl:value-of select="@GParentMaxLimit"/>__<xsl:value-of select="@TopMostGroupID"/>__<xsl:value-of select="@TMGName"/>__<xsl:value-of select="@TMGMinLimit"/>__<xsl:value-of select="@TMGMaxLimit"/>__<xsl:value-of select="@ID"/>');
            </script>-->
            <xsl:value-of select="@Name"/>
            <xsl:apply-templates/>
          </INPUT>
        </td>
      </tr>
    </table>
  </xsl:template>
  <!--
      //
			// Modified By : Rupam 
			// Date        : 2 May 2008
			//
  -->
  <xsl:template match="Paper">
    <xsl:if test="@PpHead='0'">
      <table>
        <xsl:attribute name="width">100%</xsl:attribute>
        <tr>
          <td>
            <xsl:attribute name="width">5%</xsl:attribute>
          </td>
          <td>
            <xsl:attribute name="width">95%</xsl:attribute>
            <!--
              Date : 2008 JULY 18
              Name : Neeraj
              If Paper name clicked paper should be selected or unselected like checkbox clicked
              -->
            <xsl:attribute name="onclick">return ValidateMaxLimit(document.getElementById('<xsl:value-of select="@ID"/>'),'<xsl:value-of select="@GroupID"/>',this,event);</xsl:attribute>
            <!-- Pelase DO NOT change the sequence -->
            <xsl:attribute name="ID"><xsl:value-of select="@GroupID"/>__<xsl:value-of select="@GroupName"/>__<xsl:value-of select="@GMinLimit"/>__<xsl:value-of select="@GMaxLimit"/>__<xsl:value-of select="@GParentID"/>__<xsl:value-of select="@GParentName"/>__<xsl:value-of select="@GParentMinLimit"/>__<xsl:value-of select="@GParentMaxLimit"/>__<xsl:value-of select="@TopMostGroupID"/>__<xsl:value-of select="@TMGName"/>__<xsl:value-of select="@TMGMinLimit"/>__<xsl:value-of select="@TMGMaxLimit"/>__<xsl:value-of select="@ID"/></xsl:attribute>
            <INPUT>
              <xsl:attribute name="TYPE">checkbox</xsl:attribute>
              <xsl:attribute name="ID"><xsl:value-of select="@ID"/></xsl:attribute>
              <xsl:attribute name="value"><xsl:value-of select="@value"/></xsl:attribute>
              <xsl:attribute name="title"><xsl:value-of select="@Name"/></xsl:attribute>
              <xsl:attribute name="class">chk<xsl:value-of select="@PpID"/></xsl:attribute>
              <!--<xsl:attribute name="onclick">             
                return ValidateMaxLimit(document.getElementById('<xsl:value-of select="@ID"/>'),'<xsl:value-of select="@GroupID"/>',this);
              </xsl:attribute>-->
              <xsl:if test="@Checked='checked'">
                <xsl:attribute name="checked">checked</xsl:attribute>
              </xsl:if>
              <!--<script>
                changeBackgroundColor('<xsl:value-of select="@GroupID"/>','<xsl:value-of select="@GroupID"/>__<xsl:value-of select="@GroupName"/>__<xsl:value-of select="@GMinLimit"/>__<xsl:value-of select="@GMaxLimit"/>__<xsl:value-of select="@GParentID"/>__<xsl:value-of select="@GParentName"/>__<xsl:value-of select="@GParentMinLimit"/>__<xsl:value-of select="@GParentMaxLimit"/>__<xsl:value-of select="@TopMostGroupID"/>__<xsl:value-of select="@TMGName"/>__<xsl:value-of select="@TMGMinLimit"/>__<xsl:value-of select="@TMGMaxLimit"/>__<xsl:value-of select="@ID"/>');
              </script>-->
              <xsl:apply-templates/>
              <xsl:value-of select="@Name"/>
            </INPUT>
          </td>
        </tr>
      </table>
    </xsl:if>
    <xsl:if test="@PpHead!='0'">
      <table>
        <xsl:attribute name="width">100%</xsl:attribute>
        <xsl:attribute name="ID">TDPpHead<xsl:value-of select="@ID"/></xsl:attribute>
        <tr>
          <td>
            <xsl:attribute name="width">5%</xsl:attribute>
          </td>
          <td>
            <xsl:attribute name="width">95%</xsl:attribute>
            <xsl:attribute name="ID"><xsl:value-of select="@ID"/></xsl:attribute>
            <xsl:attribute name="abbr"><xsl:value-of select="@abbr"/></xsl:attribute>
            <xsl:attribute name="title"><xsl:value-of select="@Name"/></xsl:attribute>
            <xsl:attribute name="class">chk<xsl:value-of select="@PpID"/></xsl:attribute>
            <xsl:value-of select="@Name"/>
          </td>
        </tr>
      </table>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>