import './App.css';
import React from 'react';
import { connect } from 'react-redux';
import{AddCash} from './Types/Actions/Cash';


export class AppElement extends React.Component{

  #deadline = "June, 31, 2024"
  #array = []

  #interval;

  constructor(props){
    super(props)

    this.state = {
      hour:0,
      minute:0,
      second:0,
      navigation:false
    }
    
    for(let i = 0; i <= 59; i++){
        this.#array[i] = <div>{i}</div>
    }
  }


  getTime = () => {
    const time = Date.parse(this.#deadline) - Date.now();

    this.setState({hour:Math.floor((time / (1000 * 60 * 60)) % 24)});
    this.setState({minute:Math.floor((time / 1000 / 60) % 60)});
    this.setState({second:Math.floor((time / 1000) % 60)});
    

  };

  componentDidMount() {
    this.#interval = setInterval(() => {
      this.getTime()
    }, 1000);

  }

  componentWillUnmount(){
    clearInterval(this.#interval);
  }
  
  render(){
    return (
      <div className='container-app'>
        <header className='header-app'>
          <h3 style={{marginLeft:'10px', fontStyle:'italic'}}> Notification </h3>
        </header>
        
        <main className='main-app'>
          <nav className='nav-menu'>
            <input className='search-bar-app' placeholder='search' />
            <div>
              <div className='found-element-search-bar-app'>
                10 : 10 : 10
              </div>
              <div className='found-element-search-bar-app'>
                10 : 20 : 10
              </div>
            </div>
          </nav>
            <div className='main-app-container'>
              <div className ='timer-app'>
                  <div id='timer-count-app'>
                    <div id = 'timer-app'>
                      <div id='timer-count-time-app'> {this.state.hour} : </div>
                      <div id='timer-count-time-app'> {this.state.minute} : </div>
                      <div id='timer-count-time-app3'>
                        <div id = 'seconds-app' style={{transform:`translate(0px,${-92.8 * this.state.second}px)`}}>
                        {this.#array}</div> 
                      </div>
                    </div>
                    <div style={{display:'grid'}}>

                      <div className='create-button-time-app'>
                        <input type='date' placeholder='From'/>
                        <input type='date' placeholder='To'/>
                      </div>
                      <div id='create-button-block-app'>
                        <button id='timer-count-button-time-app'>Create</button>
                      </div>
                    </div>

                  </div>
              </div>
            </div>
         
        </main>
  
  
      </div>   
    )
  }
  
}


const mapStateToProps = state => ({
  cash:state.app.cash
});

export default connect(mapStateToProps,{
  AddCash,
})(AppElement)

