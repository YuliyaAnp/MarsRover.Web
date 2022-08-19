var AppModule;
(function (AppModule) {
    var AppComponent = /** @class */ (function () {
        function AppComponent() {
        }
        AppComponent.prototype.updateTableWithPreview = function (data) {
            var counter = 1;
            var instrHtml = document.getElementById("instructions");
            instrHtml.innerHTML = "";
            for (var i = 5; i >= 0; i--) {
                document.getElementById("0-" + i).innerHTML = "&nbsp";
                document.getElementById("0-" + i).style.backgroundColor = "white";
                document.getElementById("1-" + i).innerHTML = "&nbsp";
                document.getElementById("1-" + i).style.backgroundColor = "white";
                document.getElementById("2-" + i).innerHTML = "&nbsp";
                document.getElementById("2-" + i).style.backgroundColor = "white";
                document.getElementById("3-" + i).innerHTML = "&nbsp";
                document.getElementById("3-" + i).style.backgroundColor = "white";
                document.getElementById("4-" + i).innerHTML = "&nbsp";
                document.getElementById("4-" + i).style.backgroundColor = "white";
                document.getElementById("5-" + i).innerHTML = "&nbsp";
                document.getElementById("5-" + i).style.backgroundColor = "white";
            }
            data.forEach(function (d) {
                var coords = d.coordinates.trim().split(/\s+/);
                var cell = document.getElementById(coords[0] + '-' + coords[1]);
                cell.innerHTML = counter + AppComponent.dict[coords[2]];
                cell.style.backgroundColor = '#BDEDFF';
                var instrHtml = document.getElementById("instructions");
                instrHtml.innerHTML += "Rover " + counter + ": " + d.steps + "<br>";
                counter++;
            });
        };
        AppComponent.prototype.updateTableWithResult = function (data) {
            console.log(data);
            var counter = 1;
            Object.keys(data).forEach(function (key) {
                var cell = document.getElementById(data[key].x + '-' + data[key].y);
                cell.innerHTML = counter + AppComponent.dict[String.fromCharCode(data[key].direction)];
                cell.style.backgroundColor = '#9FE2BF';
                counter++;
            });
        };
        AppComponent.dict = {
            'N': "&#11165;",
            'S': "&#11167;",
            'W': "&#11164;",
            'E': "&#11166;"
        };
        return AppComponent;
    }());
    AppModule.AppComponent = AppComponent;
})(AppModule || (AppModule = {}));
//# sourceMappingURL=app.js.map