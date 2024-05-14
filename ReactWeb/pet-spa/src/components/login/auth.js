import React, { useState, useEffect, createContext } from 'react';
import { loginApi } from '../../services/loginApi.js';
import './login.css';
import { Link } from 'react-router-dom';

export const AuthContext = createContext(
    {
        isLoggedIn: false,
        setIsLoggedIn: null,
        userId: 0,
        LogoutHandler: null,
        name: "гость",
    }
)

export const AuthProvider = ({ children }) => {
    const [isLoggedIn, setIsLoggedIn] = useState(!!localStorage.getItem("userId"))
    const [name, setName] = useState('')
    const [userId, setUserId] = useState(localStorage.getItem("userId") ? localStorage.getItem("userId") : 0)
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const { GetUserId, GetUser } = loginApi;

    useEffect(() => {
        GetUser(userId).then(response => setName(response.data.loginName))
    }, [userId])

    const SubmitHandler = (e) => {
        e.preventDefault();
        GetUserId(login, password)
            .then(response => {
                const id = response.data
                setUserId(id)
                localStorage.setItem("userId", id)
                setIsLoggedIn(true)
            });
    }

    function LogoutHandler() {
        localStorage.removeItem("userId")
        setIsLoggedIn(false)
    }

    return (
        <AuthContext.Provider
            value={{
                isLoggedIn,
                setIsLoggedIn,
                userId,
                LogoutHandler,
                name
            }}
        >
            <div className='container'>
                {isLoggedIn ?
                    (
                        <div>

                        </div>
                    ) :
                    (
                        <div class="login-page">
                            <div class="form">
                                <Link to={'/'}>
                                    <a className="close-button" />
                                </Link>
                                <form class="login-form" onSubmit={SubmitHandler}>
                                    <input type="text" required placeholder="логин" value={login} onChange={e => setLogin(e.target.value)} />
                                    <input type="password" required placeholder="пароль" value={password} onChange={e => setPassword(e.target.value)} className='passwordInput' />
                                    <button type='submit'>Войти</button>
                                    <p class="message">У вас ещё нет аккаунта?
                                        <Link to={'/user'}> Создать</Link>
                                    </p>
                                </form>
                            </div>
                        </div>
                    )}
            </div>
            {children}
        </AuthContext.Provider>
    )
}


