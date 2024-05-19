import { Link } from 'react-router-dom'
import '../login/login.css'


function SuccessfullyCreated() {
    return (
        <>
            <div className="login-page">
                <div className="form">
                    <Link to={'/'}>
                        <button className="close-button" />
                    </Link>
                    <form className="register-form">
                        <div className='done-text'>
                        Вы успешно зарегистрированы!
                        </div>
                    </form>
                </div>
            </div>
        </>
    )
}
export default SuccessfullyCreated;