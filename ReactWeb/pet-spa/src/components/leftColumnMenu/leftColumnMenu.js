import '../leftColumnMenu/site.css';
import iconCatLogo from '../../images/cat-logo.png'
import iconMyProfile from '../../images/my-profile.png'
import iconMyNews from '../../images/my-news.png'
import iconInteresting from '../../images/icon-interesting.png'
import iconCreateNewProfile from '../../images/create-new-profile.png'
import { Link } from 'react-router-dom'

function leftColumnMenu() {
    return (
        <body>
            <div class="main-container">
                <div class="navigation-leftColumn-container">
                    <div class="logo-of-site">
                        <img src={iconCatLogo} class="logo-of-site" />
                    </div>
                    <a class="item-of-column" asp-controller="UserProfile" asp-action="OpenProfile">
                        <img class="navigation-logo" src={iconMyProfile} />
                        <div class="name-of-column">Мой профиль</div>
                    </a>
                    <a class="item-of-column" asp-controller="Home" asp-action="Index">
                        <img class="navigation-logo" src={iconMyNews} />
                        <div class="name-of-column">Моя лента</div>
                    </a>
                    <a class="item-of-column" asp-controller="Home" asp-action="Index">
                        <img class="navigation-logo" src={iconInteresting} />
                        <div class="name-of-column">Интересное</div>
                    </a>
                    <a class="item-of-column" asp-controller="User" asp-action="AddUser">
                        <img class="navigation-logo" src={iconCreateNewProfile} />
                        <div class="name-of-column">Создать профиль</div>
                    </a>
                    <a class="item-of-column" >
                        <Link to={'/login'}>Войти</Link>
                    </a>
                </div>
            </div>
        </body>
    )
};

export default leftColumnMenu;