// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function () {
    var textContainer = document.getElementById('text-container');
    var text = "I AM LAWE ZANGENA";
    var delay = 250; // Delay in milliseconds (adjust as needed)
    var index = 0;
    var delay2 = 250 * text.length;

    function displayText() {
        if (index < text.length) {
            textContainer.innerHTML += text.charAt(index);
            index++;
            setTimeout(displayText, delay);
        }
    }
    function hideCursor() {
        document.getElementById('cursor').style = "display: none"
    }
    setTimeout(hideCursor, delay2);
    displayText();
});
const items = document.querySelectorAll('.transparent-nav-item');

items.forEach(item => {
    item.addEventListener('click', () => {
        items.forEach(otherItem => {
            otherItem.classList.remove('active');
        });
        item.classList.add('active');
    });
});
window.addEventListener('load', function () {
    var rollingContent = document.getElementsByClassName('rolling-content');
    Array.from(rollingContent).forEach(function (content) {
        content.classList.add('loaded');
    });
});

const contactButton = document.getElementById('contact-button');

contactButton.addEventListener('mouseenter', function () {
    this.classList.add('hovered');
});

contactButton.addEventListener('mouseleave', function () {
    this.classList.remove('hovered');
});

