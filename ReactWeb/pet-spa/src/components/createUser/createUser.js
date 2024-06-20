import React, { useState, useEffect } from "react";
import CreateUserApi from '../../services/createUserApi.js'
import { Link } from 'react-router-dom'
import '../login/login.css'
import { useNavigate } from 'react-router-dom';

function CreateUser() {
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');
    const navigate = useNavigate();

    const SubmitHandler = (e) => {
        e.preventDefault();
        CreateUserApi(login, password, email)
    };

    function Done() {
        navigate('/done');
    }

    return (
        <>
            <div className="login-page">
                <div className="form">
                    <Link to={'/'}>
                        <button className="close-button" />
                    </Link>
                    <form className="user-form" onSubmit={SubmitHandler}>
                        <input type="text" required placeholder="имя пользователя" value={login} onChange={e => setLogin(e.target.value)} />
                        <input type="password" required placeholder="пароль" value={password} onChange={e => setPassword(e.target.value)} />
                        <input type="email" required placeholder="email адрес" value={email} onChange={e => setEmail(e.target.value)} />
                        <button onClick={Done}>Создать аккаунт</button>
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