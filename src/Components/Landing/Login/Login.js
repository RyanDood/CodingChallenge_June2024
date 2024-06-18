import { useState } from "react";
import "../../../../src/Components/style.css"
import { Link, useNavigate } from "react-router-dom";
import axios from 'axios';



function Login(){

    var [userName,setUserName]= useState("");
    var [password,setPassword]= useState("");
    var [error,setError]= useState(false);
    var [errorMessage,setErrorMessage]= useState("");
    var navigate = useNavigate();

    function checkUserNameValidation(eventargs){
        var username = eventargs.target.value;
        setUserName(username)
    }

    var enter = {
        "userName": userName,
        "password": password
      }

    async function login(){
        await axios.post('https://localhost:7147/api/User/Login',enter).then(function (response) {
                setError(false);
                sessionStorage.setItem("memberID",response.data.userID);
                navigateToHome(response.data);
            })
            .catch(function (error) {
                console.log(error);
                setError(true);
                setErrorMessage(error.response.data);
            })
    }

    function navigateToHome(data){
        if(data.isAdmin){
            setTimeout(() => {
                navigate("/allMembers");
            }, 2000);
        }
        else{
            setTimeout(() => {
                navigate("/allevents");
            }, 2000);
        }
    }

    function checkPasswordValidation(eventargs){
        var password = eventargs.target.value;
        setPassword(password);
        if(password !== ""){
            if(password.length >= 8 && password.length <= 15){
                setError(false);
                if(userName !== ""){
                    document.getElementById("loginButton").classList.remove("disabled");
                }
            }
            else{
                document.getElementById("loginButton").classList.add("disabled");
                setError(true);
                setErrorMessage("Password length should be between 8-15 characters");
            }
        }
        else{
            document.getElementById("loginButton").classList.add("disabled");
            setError(true);
            setErrorMessage("Password cannot be empty");
        }
    }


    return (
        <div>
            <div className="smallBox4 col-sm-12">
                    <div className="smallBox7">
                        <div className="smallBox5">
                            <span className="welcomeText2">Welcome to HexaGYM</span>
                            <span className="welcomeText3">Welcome to HexaEvent</span>
                            <div>
                                <span className="clickRegisterText">UserName</span>
                                <input className="form-control enterDiv" type="text" value={userName} onChange={checkUserNameValidation}></input>
                            </div>
                            <div>
                                <span className="clickRegisterText">Password</span>
                                <input className="form-control enterDiv" type="password" value={password} onChange={checkPasswordValidation}></input>
                            </div>
                        </div>
                        {error ? <div className='flexRow margin6 errorText'>{errorMessage}</div> : null}
                        <div className="smallBox8">
                            <Link className="btn btn-outline-warning smallBox9" to="/register">
                                <span>Register</span>
                            </Link>
                            <div className="pad">
                                <a id="loginButton"  onClick={login} className="btn btn-outline-warning smallBox9 disabled">
                                    <span>Login</span>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
        </div>
    );
}

export default Login;