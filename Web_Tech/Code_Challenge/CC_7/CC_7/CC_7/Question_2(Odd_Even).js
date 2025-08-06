function checkOddEven() {
    var output = "";
    for (var i = 0; i <= 15; i++) {
        if (i % 2 === 0) {
            output += i + " is even<br>";
        } else {
            output += i + " is odd<br>";
        }
    }
    document.getElementById("oddevenresult").innerHTML = output;
}