Imports System.IO
Imports System.Reflection
Imports System.Security.Permissions
Imports System.Text
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")>
<System.Runtime.InteropServices.ComVisible(True)>
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.wbmap.ObjectForScripting = Me

        Dim onlyPositions As Double(,) = New Double(2, 1) {{42.13557, -0.40806}, {42.13684, -0.40884}, {42.13716, -0.40729}}
        Dim positonAndTitles As String(,) = New String(2, 2) {{"42.13557", "-0.40806", "marker0"}, {"42.13684", "-0.40884", "marker1"}, {"42.13716", "-0.40729", "marker2"}}
        Dim positonTitlesAndIcons As String(,) = New String(2, 3) {{"42.13557", "-0.40806", "marker0", "truck_red.png"}, {"42.13684", "-0.40884", "marker1", "truck_red.png"}, {"42.13716", "-0.40729", "marker2", "truck_red.png"}}

        'Dim gmh As GoogleMapHelper = New GoogleMapHelper(wbmap, onlyPositions)
        'Dim gmh As GoogleMapHelper = New GoogleMapHelper(wbmap, positonAndTitles)
        Dim gmh As GoogleMapHelper = New GoogleMapHelper(wbmap, positonTitlesAndIcons)
        gmh.loadMap()
    End Sub

    '############################### CALLING JAVASCRIPT METHODS ##############################
    'This methods call methods written in googlemap_template.html
    Private Sub callMapJavascript(sender As Object, e As EventArgs) Handles Button1.Click
        wbmap.Document.InvokeScript("showJavascriptHelloWorld")
    End Sub

    Private Sub callMapJavascriptWithArguments(sender As Object, e As EventArgs) Handles Button2.Click
        wbmap.Document.InvokeScript("focusMarkerFromIdx", New String() {2})
    End Sub
    '#########################################################################################

    '############################### METHODS CALLED FROM JAVASCRIPT ##########################
    'This methods are called by the javascript defined in googlemap_template.html when some events are triggered
    Public Sub getMarkerDataFromJavascript(title As String, idx As String)
        MsgBox("Title: " & title & " idx: " & idx)
    End Sub

    Public Sub showVbHelloWorld()
        MsgBox("Hello world in WF from HTML")
    End Sub
End Class