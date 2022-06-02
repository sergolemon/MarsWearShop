var index = 1;
function showMore() {
    var xhr = new XMLHttpRequest();

    xhr.open("POST", location.href, true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.send("index=" + index);

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            var doc = new DOMParser().parseFromString(this.responseText, "text/html");

            var elements = doc.querySelectorAll(".product-card");

            if (elements.length == 0) document.querySelector(".show-more-box").style.display = "none";

            for (var i = 0; i < elements.length; i++) {
                document.querySelector(".products-list").appendChild(elements[i]);
            }
            index++;
        }
    }
}

function signIn() {
    var login = document.querySelector("input[name=login]").value;
    var password = document.querySelector("input[name=password]").value;

    var xhr = new XMLHttpRequest();

    xhr.open("POST", "/account/login", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.send("login=" + login + "&password=" + password);

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            var data = JSON.parse(this.responseText);

            if (data.success) {

            } else {
                document.querySelector("#sign-in-box > form > .msg-box > small").innerText = data.msg;
            }
        }
    }
}

function getAdditionalImg(event) {
    var el = event.currentTarget;

    titleImg = el.getAttribute("src");
    el.setAttribute("src", el.getAttribute("data-additional"));
}

function getTitleImg(event) {
    var el = event.currentTarget;
    
    if(titleImg != null) el.setAttribute("src", titleImg);
}

function openForm() {
    document.querySelector("#sign-in-box").classList.add("active");
}

function closeForm() {
    document.querySelector("#sign-in-box").classList.remove("active");
}

function toggleCategories() {
    document.querySelector(".nav.catalog-box > .categories-box").classList.toggle("active");
}

function toggleMenu() {
    window.scrollTo(0, 0);
    document.querySelector("nav").classList.toggle("active");
    document.querySelector("#nav-shadow-box").classList.toggle("active");
    document.querySelector(".header.menu-toggler-box > button").classList.toggle("active");
    document.querySelector(".nav.catalog-box > .categories-box").classList.remove("active");
    document.querySelector("body").classList.toggle("fixed");
}

function startPage() {
    Initializer();
    CartPriceInit();
    SetCartTotalPrice();
    BuildCart();
}

function resizePage() {
    Initializer();

    document.querySelector("nav").classList.remove("active");
    document.querySelector("#nav-shadow-box").classList.remove("active");
    document.querySelector(".header.menu-toggler-box > button").classList.remove("active");
    document.querySelector(".nav.catalog-box > .categories-box").classList.remove("active");
    document.querySelector("body").classList.remove("fixed");
}

function scrollToTop() {
    document.querySelector('body').scrollIntoView({ behavior: 'smooth' });
}

function scrollPage() {
    var stt = document.querySelector("#scroll-to-top");

    if (window.pageYOffset > document.documentElement.clientHeight) stt.style.display = "block";
    else stt.style.display = "none";
}

function Initializer() {
    document.querySelector(".nav.first").style.height = document.querySelector("header").offsetHeight + "px";
}

var lastMsgBox, timeoutId;
function AddToCartItem(event) {
    var id = event.currentTarget.getAttribute("data-prod-id");
    var size = event.currentTarget.closest(".product-card").querySelector("input[type=radio].size-btn:checked").getAttribute("value");
    var msgBox = event.currentTarget.closest(".product-card").querySelector(".to-cart-result");

    var xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            msgBox.querySelector("span").innerText = this.responseText;
            msgBox.style.display = "flex";

            if (lastMsgBox != null && msgBox != lastMsgBox) {
                lastMsgBox.style.display = "none";
            }

            clearTimeout(timeoutId);
            timeoutId = setTimeout(() => {
                lastMsgBox.style.display = "none";
            }, 1700);

            lastMsgBox = msgBox;

            if (this.responseText == 1) {
                var el = document.querySelector(".header.cart-box .cart-items-count");

                el.innerText = Number(el.innerText) + 1;


                var load = new XMLHttpRequest();

                load.onreadystatechange = function () {
                    if (load.readyState == 4 && load.status == 200) {
                        var doc = new DOMParser().parseFromString(this.responseText, "text/html");

                        var p = document.querySelector("#cart > .cart-items-box > p");
                        p.style.display = "none";
                        document.querySelector("#cart > .bottom").style.display = "block";

                        document.querySelector("#cart > .cart-items-box").appendChild(doc.querySelector(".cart-item"));

                        var item = document.querySelector("#cart .cart-items-box").lastElementChild;

                        SetSumCartItem(item);
                    }
                }

                load.open("POST", "/cart/loadnewitem", false);
                load.send();
            }
            else {
                var items = document.querySelectorAll("#cart .cart-item");
                var item;
                for (var i = 0; i < items.length; i++) {
                    if (items[i].querySelector(".options > .size > span").innerText == size && items[i].getAttribute("data-prodId") == id) {
                        item = items[i];
                        break;
                    }
                }

                item.querySelector("div.count span.count").innerText = xhr.responseText;
                SetSumCartItem(item);
            }

            SetCartTotalPrice();
        }
    }

    xhr.open("POST", "/cart/addToCartItem", false);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.send("productId=" + id + "&size=" + size);
}

function hideThis(event) {
    event.currentTarget.style.display = "none";
}

function OpenCart() {
    document.querySelector("#cart").classList.add("active");
    document.querySelector("#cart-background").classList.add("active");
    document.querySelector("body").classList.add("fixed");
}

function CloseCart() {
    document.querySelector("#cart").classList.remove("active");
    document.querySelector("#cart-background").classList.remove("active");
    document.querySelector("body").classList.remove("fixed");
}

function CartItemDelete(event) {
    var xhr = new XMLHttpRequest();
    var el = event.currentTarget;

    xhr.open("POST", "/cart/deleteitem", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.send("id=" + event.currentTarget.value);

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            el.closest(".cart-item").remove();

            var cartNum = document.querySelector(".header.cart-box .cart-items-count");

            cartNum.innerText = Number(cartNum.innerText) > 1 ? Number(cartNum.innerText) - 1 : "";

            SetCartTotalPrice();
            BuildCart();
        }
    }
}

function CartItemMinus(event) {
    var xhr = new XMLHttpRequest();
    var el = event.currentTarget;

    xhr.open("POST", "/cart/minusitem", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.send("id=" + event.currentTarget.value);

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            el.closest(".num-container").querySelector("span.count").innerText = this.responseText;
            SetSumCartItem(el.closest(".cart-item"));
            SetCartTotalPrice();
        }
    }
}

function CartItemPlus(event) {
    var xhr = new XMLHttpRequest();
    var el = event.currentTarget;

    xhr.open("POST", "/cart/plusitem", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.send("id=" + event.currentTarget.value);

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            el.closest(".num-container").querySelector("span.count").innerText = this.responseText;
            SetSumCartItem(el.closest(".cart-item"));
            SetCartTotalPrice();

        }
    }
}

function ClearCart() {
    var xhr = new XMLHttpRequest();

    xhr.open("POST", "/cart/clearcart", true);
    xhr.send();

    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            var items = document.querySelectorAll("#cart .cart-item");
            for (var i = 0; i < items.length; i++) {
                items[i].remove();
            }
            var el = document.querySelector(".header.cart-box .cart-items-count");

            el.innerText = "";

            document.querySelector("#cart > .bottom").style.display = "none";
            document.querySelector("#cart > .cart-items-box > p").style.display = "block";
        }
    }
}

function SetSumCartItem(el) {
    var count = el.querySelector("span.count").innerText;
    var price = el.querySelector(".price > span").getAttribute("data-price");

    el.querySelector(".price > span").innerText = count * price;
}

function CartPriceInit() {
    var items = document.querySelectorAll(".cart-item");

    for (var i = 0; i < items.length; i++) {
        SetSumCartItem(items[i]);
    }
}

function SetCartTotalPrice() {
    var items = document.querySelectorAll(".cart-item");
    var totalPrice = 0;

    for (var i = 0; i < items.length; i++) {
        totalPrice += Number(items[i].querySelector(".price > span").innerText);
    }

    document.querySelector("#cart > .bottom .total-price").innerText = totalPrice;
}

function BuildCart() {
    if (document.querySelectorAll(".cart-item").length == 0) {
        document.querySelector("#cart > .bottom").style.display = "none";
        document.querySelector("#cart > .cart-items-box > p").style.display = "block";
    }
    else {
        document.querySelector("#cart > .bottom").style.display = "black";
        document.querySelector("#cart > .cart-items-box > p").style.display = "none";
    }
}

function CheckCart() {

}