import {React} from "react";
import { Component } from "react";
import '../../App.css';

class NotificationStoreElement  extends Component {

    render(){
        return (
            
            <div id = "notification-store-flex">
                
                <div id = "notification-store-main">
                    <header id="notification-store-header">
                        <input placeholder="Search" id="notification-store-searchbar"/>
                        <button style={{fontSize:15,padding:9}}>Search</button>
                    </header>

                    <main>
                        <div id="container-time">
                            <div id="container">
                                <ul>
                                    <li>
                                        <div id = "time"> 12 </div> : <div id= "time">01</div> : <div id = "time">45</div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </main>
                </div>

            </div>
        )
    }
}
export default NotificationStoreElement;