import React, { useState, useEffect } from "react";
import CreateUserApi from '../../services/createUserApi.js'
import { Link } from 'react-router-dom'
import '../login/login.css'

function CreateUser() {
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');

    const SubmitHandler = (e) => {
        e.preventDefault();
        CreateUserApi(login, password, email)
    };

    return (
        <> <div class="login-page">
            <div className="form">
                <Link to={'/'}>
                    <a className="close-button"></a>
                </Link>
                <form className="register-form" onSubmit={SubmitHandler}>
                    <input type="text" required placeholder="имя пользователя" value={login} onChange={e => setLogin(e.target.value)} />
                    <input type="password" required placeholder="пароль" value={password} onChange={e => setPassword(e.target.value)} />
                    <input type="email" required placeholder="email адрес" value={email} onChange={e => setEmail(e.target.value)} />
                    <button>Создать аккаунт</button>
                    <p className="message">Уже есть аккаунт?
                        <Link to={'/login'}> Войти</Link>
                    </p>
                </form>
            </div>
        </div>
        </>
    )
}
export default CreateUser;