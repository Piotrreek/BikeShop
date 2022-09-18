const main = () => {
    const faBars = document.querySelector(".fa-bars")
    const faXMark = document.querySelector(".fa-xmark")
    const burger = document.querySelector(".burger")
    const switchThemeBtn = document.querySelector(".switch-light-dark")
    const nav = document.querySelector("nav")
    const faMoon = document.querySelector('.fa-moon')
    const faSun = document.querySelector('.fa-sun')
    const registerSuccessful = document.querySelector('.registerSuccessful')
    

    const checkTheme = () =>{
        if(localStorage.getItem("data-theme") === 'dark'){
            faSun.classList.remove("hide")
            faMoon.classList.add('hide')
            document.documentElement.setAttribute("data-theme", "dark") 
        }else{
            faSun.classList.add("hide")
            faMoon.classList.remove('hide')
            document.documentElement.setAttribute("data-theme", "light") 
        }
    }
    checkTheme()
    
    const removeRegisterInfo = () =>{
        if(registerSuccessful != null){
            registerSuccessful.classList.add('hide')
        }
    }
    
    const toggleBurger = () => {
        faBars.classList.toggle('hide')
        faXMark.classList.toggle('hide')
        nav.classList.toggle('nav-show')
    }

    const changeThemeToDark = () => {
        document.documentElement.setAttribute("data-theme", "dark") 
        localStorage.setItem("data-theme", "dark") 
    }

    const changeThemeToLight = () => {
        document.documentElement.setAttribute("data-theme", "light") 
        localStorage.setItem("data-theme", 'light') 
    }
    
    const switchTheme = () =>{
        faMoon.classList.toggle('hide')
        faSun.classList.toggle('hide')
        let theme = localStorage.getItem('data-theme');
        if (theme ==='dark'){
            changeThemeToLight()
        }else{
            changeThemeToDark()
        }
    }
    registerSuccessful.addEventListener('click', removeRegisterInfo)
    burger.addEventListener('click', toggleBurger)
    switchThemeBtn.addEventListener('click', switchTheme)
}
document.addEventListener("DOMContentLoaded", main);