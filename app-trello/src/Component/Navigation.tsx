import { Button } from 'primereact/button';
import React from 'react';
import { Link } from 'react-router-dom';

const navStyle = {
    display: 'flex',
    justifyContent: 'space-between',
    margin: 10
};

const linkStyle = {
    display: 'inline',
    marginRight: '20px',
    textDecoration: 'none',
    color: 'blue',
};

const btnStyle = {
    display: 'flex',
    marginRight: '20px',
    textDecoration: 'none',
    height: 30,
    marginTop: 10,
    justifyContent: 'space-between',

};

interface INavigationProps {
    setConnected: React.Dispatch<React.SetStateAction<boolean>>
}
function Navigation({ setConnected }: INavigationProps) {

    const handleLogin = async () => {
        setConnected(false)
    };
    return (
        <div style={{ background: '#282c34' }}>
            <nav style={navStyle}>
                <ul>
                    <li style={linkStyle}>
                        <Link to="/">ACCUEIL</Link>
                    </li>
                    <li style={linkStyle}>
                        <Link to="/profile">UTILISATEUR</Link>
                    </li>
                    <li style={linkStyle}>
                        <Link to="/projet">PROJET</Link>
                    </li>

                </ul>
                <Button style={btnStyle} label="Deconnexion" icon="pi pi-check" onClick={handleLogin} />
            </nav>

        </div>
    );
}


export default Navigation;