import './mainMenu.css';
import iconCatLogo from '../../images/logo.png'
import iconMyProfile from '../../images/my-profile.png'
import iconMyNews from '../../images/my-news.png'
import iconInteresting from '../../images/icon-interesting.png'
import { Link } from 'react-router-dom'
import { AuthContext } from '../login/auth';
import { useContext } from 'react';

function LeftColumnMenu() {
    const { isLoggedIn, setIsLoggedIn, LogoutHandler } = useContext(AuthContext)

    return (
        <>
            <div className="main-container">
                <div className="navigation-leftColumn-container">
                    <div className="logo-of-site">
                        <img src={iconCatLogo} class="logo-of-site" />
                    </div>
                    <button className="item-of-column" >
                        <img className="navigation-logo" src={iconMyProfile} />
                        <Link to={'/profile'} className="name-of-column">Мой профиль</Link>
                    </button>
                    <button className="item-of-column">
                        <img className="navigation-logo" src={iconMyNews} />
                        <div className="name-of-column">Моя лента</div>
                    </button>
                    <button className="item-of-column">
                        <img className="navigation-logo" src={iconInteresting} />
                        <div className="name-of-column">Интересное</div>
                    </button>
                    {isLoggedIn ? (
                        <button className="item-of-column name-of-column" onClick={LogoutHandler}>
                            <div className="name-of-column logout">Выйти</div>
                        </button>)
                        : (
                            <button className="item-of-column">
                                <Link to={'/login'} className="name-of-column login">Войти</Link>
                            </button>)
                    }
                </div>
            </div>
        </>
    )
};

export default LeftColumnMenu;