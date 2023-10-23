import { Component } from "react";
import { addAlarm } from "../../addAlarm";
import { connect } from "react-redux";
import { WebApi } from "../../web-api";

class Timer extends Component {
    #array = []

    constructor(props)
    {
        super(props)
        
        // UseState stuff
        this.state = {
          hour:0,
          minute:0,
          second:0,
          alarms:[]
        }
        
        // _fields
        this.deadline = "June, 31, 24"
        this.interval = null;

        for(let i = 0; i <= 59; i++) this.#array[i] = <div>{i}</div> 
    }

    
  getTime = () => {
    const time = Date.parse(this.deadline) - Date.now();

    this.setState({hour:Math.floor((time / (1000 * 60 * 60)) % 24)});
    this.setState({minute:Math.floor((time / 1000 / 60) % 60)});
    this.setState({second:Math.floor((time / 1000) % 60)});
    

  };

  componentDidMount() {
    this.interval = setInterval(() => {
      this.getTime()
    }, 1000);

    const el = document.getElementById("timer-app");
    const height = el.getBoundingClientRect().height.toFixed(1);
    this.setState({height:0.0 - height});
  }

  componentWillUnmount(){
    clearInterval(this.interval);
    }

    PostAsync() {
       PostAlarms(this.props.dispatch);
       GetAlarms(this.props.dispatch);
    }

    render() {
        return(
            <div className='main-app-container'>           
                <div className ='timer-app'>
                    <div id='timer-count-app'>
                        <div id = 'timer-app'>
                        <div id='timer-count-time-app'> {this.state.hour} : </div>
                        <div id='timer-count-time-app'> {this.state.minute} : </div>
                        <div id='timer-count-time-app3'>
                            <div id = 'seconds-app' style={{transform:`translate(0px,${this.state.height * this.state.second}px)`}}>
                            {this.#array}</div> 
                        </div>
                    </div>
                    <div style={{display:'grid'}}>
                        <div className='create-button-time-app'>
                            <input type='date' placeholder='To'/>
                        </div>
                            <div id='create-button-block-app'>
                                <button id='timer-count-button-time-app' onClick={() => this.PostAsync()}>Create</button>
                        </div>
                    </div>

                </div>
            </div>
            </div>
        )
    }
}
const mapStateToProps = state => ({
    alarms: state.alarm.alarms
  });

export const GetAlarms = (dispatch) => {
    const WebAPIs = new WebApi();
    dispatch(WebAPIs.GetAlarms());
}

export const PostAlarms = (dispatch) => {
    const WebAPIs = new WebApi();
    dispatch(WebAPIs.PostAlarm());
}
  
  export default connect(mapStateToProps)(Timer)