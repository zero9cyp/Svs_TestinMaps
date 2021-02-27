<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default3.aspx.vb" Inherits="SvsMapPointersDB.Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Show or Integrate Google Maps in asp.net webapplication</title>
    <style type="text/css">
        html {
            height: 100%
        }

        body {
            height: 100%;
            margin: 0;
            padding: 0
        }

        #map_canvas {
            height: 100%
        }
    </style>
    <script type="text/javascript"
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6v5-2uaq_wusHDktM9ILcqIrlPtnZgEk&sensor=false">
    </script>
    <script type="text/javascript">
        function initialize() {
            var markers = JSON.parse('<%=ConvertDataTabletoString() %>');
            var myLatlng = new google.maps.LatLng(34.400, 33.150)
            var mapOptions = {
                center: new google.maps.LatLng(markers[0].lat, markers[0].lng),//myLatlng, //new google.maps.LatLng(markers[0].lat, markers[0].lng),
                zoom: 5,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
               // marker: true
            };

            var infoWindow = new google.maps.InfoWindow();
            var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
           for (i = 0; i < markers.length; i++) {
                var data = markers[i]
                var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: data.title
        }
    </script>



</head>
<body onload="initialize()">
    <form id="form1" runat="server">
        <div id="map_canvas" style="width: 500px; height: 300px"></div>
    </form>
</body>
</html>