function multiply() {
    var num1 = document.getElementById("firstNumber").value;
    var num2 = document.getElementById("secondNumber").value;
    var result = Number(num1) * Number(num2);
    document.getElementById("result").innerHTML = "The Result Is : " + result;
}

function divide() {
    var num1 = document.getElementById("firstNumber").value;
    var num2 = document.getElementById("secondNumber").value;
    if (Number(num2) === 0) {
        document.getElementById("result").innerHTML = "The Result Is : Cannot divide by zero";
    } else {
        var result = Number(num1) / Number(num2);
        document.getElementById("result").innerHTML = "The Result Is : " + result;
    }
}