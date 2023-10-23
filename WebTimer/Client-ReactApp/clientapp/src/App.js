import './App.css';
import React from 'react';
import { connect } from 'react-redux';
import { AddCash } from './Types/Actions/Cash';
import Navbar from './Components/Layout/Navbar';
import Menu from './Components/Layout/Menu';
import Timer from './Components/Layout/Timer';
import Container from './Components/Layout/Container';


export class AppElement extends React.Component{
  render(){
    return (
      <Container>
          <Navbar/>
          <main className='main-app'>
            <Menu/>
            <Timer/>
          </main>
      </Container>  
    )
  }
  
}


const mapStateToProps = state => ({
  cash: state.app.cash,
  alarms: state.alarm.alarms
});

export default connect(mapStateToProps)(AppElement)

