function initMap() {
    // The location of Uluru
    var OGSportsHQ = { lat: 32.793417, lng: 34.956824 };
    // The map, centered at Uluru
    var map = new google.maps.Map(
        document.getElementById('map'), { zoom: 15, center: OGSportsHQ });
    // The marker, positioned at Uluru
    var marker = new google.maps.Marker({ position: OGSportsHQ, map: map });
}

function GetMap(){
    var map = new Microsoft.Maps.Map('#myMap', {
        credentials: 'AnbSrkGehUy5t79l23yv8H2E31zawiB13nHZQuZgubkVOFIcvB4_w9xDjF5a84N0',
        center: new Microsoft.Maps.Location(32.793417, 34.956824),
        mapTypeId: Microsoft.Maps.MapTypeId.Hybrid,
        zoom: 15
    });

    var center = map.getCenter();

    //Create custom Pushpin
    var pin = new Microsoft.Maps.Pushpin(center, {
        title: 'OGSports',
        subTitle: 'מטה החברה',
        text: '',
    });

    //Add the pushpin to the map
    map.entities.push(pin);
}