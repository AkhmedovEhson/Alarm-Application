import { Component } from "react";

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
          navigation:false
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

  }

  componentWillUnmount(){
    clearInterval(this.interval);
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
                            <div id = 'seconds-app' style={{transform:`translate(0px,${-92.8 * this.state.second}px)`}}>
                            {this.#array}</div> 
                        </div>
                    </div>
                    <div style={{display:'grid'}}>

                        <div className='create-button-time-app'>
                            <input type='date' placeholder='To'/>
                        </div>
                        <div id='create-button-block-app'>
                            <button id='timer-count-button-time-app'>Create</button>
                        </div>
                    </div>

                </div>
            </div>
            </div>
        )
    }
}
export default Timer;