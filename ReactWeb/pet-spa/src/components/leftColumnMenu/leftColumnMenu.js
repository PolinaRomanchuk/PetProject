import '../leftColumnMenu/site.css';
import iconCatLogo from '../../images/cat-logo.png'
import iconMyProfile from '../../images/my-profile.png'
import iconMyNews from '../../images/my-news.png'
import iconInteresting from '../../images/icon-interesting.png'
import iconCreateNewProfile from '../../images/create-new-profile.png'
import { Link } from 'react-router-dom'
import { AuthContext } from '../login/auth';
import { useContext } from 'react';

function LeftColumnMenu() {
    {/*const [modalActive, setModalActive] = useState(false)*/ }
    const { isLoggedIn, setIsLoggedIn, LogoutHandler } = useContext(AuthContext)

    return (
        <>
            <div className="main-container">
                <div className="navigation-leftColumn-container">
                    <div className="logo-of-site">
                        <img src={iconCatLogo} class="logo-of-site" />PurrfectShots
                    </div>
                    <a className="item-of-column" >
                        <img className="navigation-logo" src={iconMyProfile} />

                        <Link to={'/profile'} className="name-of-column">Мой профиль</Link>
                    </a>
                    <a className="item-of-column" asp-controller="Home" asp-action="Index">
                        <img className="navigation-logo" src={iconMyNews} />
                        <div className="name-of-column">Моя лента</div>
                    </a>
                    <a className="item-of-column" asp-controller="Home" asp-action="Index">
                        <img className="navigation-logo" src={iconInteresting} />
                        <div className="name-of-column">Интересное</div>
                    </a>
                    <a className="item-of-column" asp-controller="User" asp-action="AddUser">
                        <img className="navigation-logo" src={iconCreateNewProfile} />
                        <div className="name-of-column">Создать профиль</div>
                    </a>
                    {isLoggedIn ? (
                        <a className="item-of-column" onClick={LogoutHandler}>Выйти</a>
                    ) :
                        (
                            <a >
                                <Link to={'/login'} className="item-of-column">Войти</Link>
                            </a>)
                    }
                    {/*<a className="item-of-column" onClick={() => setModalActive(true)}>Войти</a>
                    <Modal active={modalActive} setActive={setModalActive}>
                    <Login></Login></Modal>*/}
                </div>
            </div>
        </>
    )
};

export default LeftColumnMenu;