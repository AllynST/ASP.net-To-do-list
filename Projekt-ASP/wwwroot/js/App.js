
let LoginWindow = document.getElementById("LoginWindow");
let container = document.getElementById("container");

state = false;

const LoginWindowPopUp = () => {
    if (state) {// if window is open
        LoginWindow.style.display = "none"
        container.style.animation = "blackOut 0.1s forwards reverse"
        
    }
    else {
        LoginWindow.style.display = "flex"
        container.style.animation = "blackOut 0.1s forwards"
    }
    state = !state
}