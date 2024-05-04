import React, { useState, useEffect } from "react";
import CreateUserByApi from '../../services/createUserByApi.js'
import { Link } from 'react-router-dom'
import '../login/login.css'


function CreateUser() {

    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');

    const SubmitHandler = (e) => {
        e.preventDefault();
        CreateUserByApi(login, password, email)
    };

    return (
        <> <div class="login-page">
            <div className="form">
                <form className="register-form" onSubmit={SubmitHandler}>
                    <input type="text" placeholder="name" value={login} onChange={e => setLogin(e.target.value)} />
                    <input type="password" placeholder="password" value={password} onChange={e => setPassword(e.target.value)} />
                    <input type="text" placeholder="email address" value={email} onChange={e => setEmail(e.target.value)} />
                    <button>Создать аккаунт</button>
                    <p className="message">Уже есть аккаунт? 
                    <Link to={'/login'}>Войти</Link>
                    </p>
                </form>
            </div>
        </div>
        </>
    )
}
export default CreateUser;