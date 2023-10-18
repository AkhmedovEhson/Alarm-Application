import {React,Component} from 'react';
import '../../App.css';
class Menu extends Component {
    
    render() {
        return(
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
        )
    }
}
export default Menu;