import React, {useState, useEffect} from 'react';
import { loginApi } from '../../services/loginApi.js';
import './login.css';

function Login() {
    const [isLoggedIn, setIsLoggedIn] = useState(!!localStorage.getItem("userId"))
    const [name, setName] = useState()
    const [userId, setUserId] = useState(localStorage.getItem("userId") ? localStorage.getItem("userId") : 0)
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const {GetUserId, GetUser} = loginApi;

    useEffect(()=>{
        GetUser(userId).then(response => setName(response.data.name))
    }, [userId])

    const SubmitHandler=(e)=>{
        e.preventDefault();
        GetUserId(login, password)
        .then(response => {
            const id = response.data
            setUserId(id)
            localStorage.setItem("userId", id)
            setIsLoggedIn(true)
        });
    }

    function LogoutHandler(){
        localStorage.removeItem("userId")
        setIsLoggedIn(false)
    }

    return (
        <div className='container'> 
        { isLoggedIn ? 
            (
                <div className='userBlock'>
                    <button onClick={LogoutHandler} className='logoutButton'>Выйти</button>
                </div>
            ) :
            
            (
                <form onSubmit={SubmitHandler} className='loginForm'>
                    <div className='loginBlock'>
                        <p className='loginTitle'>Введите login:</p>
                        <input type='text' value={login} onChange={e => setLogin(e.target.value) } className='loginInput'></input>
                    </div>
                    <div className='passwordBlock'>
                        <p className='passwordTitle'>Введите пароль</p>
                        <input type='password' value={password} onChange={e => setPassword(e.target.value)} className='passwordInput'></input>
                    </div>
                    <button type='submit'>Войти</button>
                </form>) }
        </div>
    )
}

export default Login;