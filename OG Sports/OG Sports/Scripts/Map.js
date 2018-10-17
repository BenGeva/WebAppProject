/*function myMap() {
    var mapCanvas = document.getElementById("map");
    var mapOptions = {
        center: new google.maps.LatLng(51.5, -0.2),
        zoom: 10
    };
    var map = new google.maps.Map(mapCanvas, mapOptions);
}*/

function initMap() {
    // The location of Uluru
    var OGSportsHQ = { lat: 32.793417, lng: 34.956824 };
    // The map, centered at Uluru
    var map = new google.maps.Map(
        document.getElementById('map'), { zoom: 15, center: OGSportsHQ });
    // The marker, positioned at Uluru
    var marker = new google.maps.Marker({ position: OGSportsHQ, map: map });
}