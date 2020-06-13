import React from 'react'
import { NavLink } from 'react-router-dom'
import './style.css'

const Menu = () => {
  return (
    <div className="menu_top">
      <ul>
        <li>
          <NavLink to="/homes">Дома</NavLink>
        </li>
        <li>
          <NavLink to="/staff">Сотрудники</NavLink>
        </li>
        <li>
          <NavLink to="/proposal">Заявки</NavLink>
        </li>
        <li>
          <NavLink to="/polling">Опросы</NavLink>
        </li>
        <li>
          <NavLink to="/meetings">Встречи</NavLink>
        </li>
      </ul>
    </div>
  )
}

export default Menu
