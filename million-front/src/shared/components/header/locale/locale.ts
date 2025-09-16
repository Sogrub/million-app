// Interfaces
import { HeaderLocale } from "../interfaces/header.interfaces";

export const HEADER_LOCALE_ES: HeaderLocale = {
    title: "Million Builder",
    menuTitle: "Menu",
    options: [
        {
            text: "Inicio",
            href: "/",
        },
        {
            text: "En venta",
            href: "/properties",
            params: {
                type: "sell"
            }
        },
        {
            text: "En arriendo",
            href: "/properties",
            params: {
                type: "rent"
            }
        },
    ],
    contactText: "Contáctanos",
    languageOptions: [
        {
            text: "Ingles",
            key: "en"
        },
        {
            text: "Español",
            key: "es"
        }
    ]
}

export const HEADER_LOCALE_EN: HeaderLocale = {
    title: "Million Builder",
    menuTitle: "Menu",
    options: [
        {
            text: "Home",
            href: "/",
        },
        {
            text: "Sell",
            href: "/properties",
            params: {
                type: "sell"
            }
        },
        {
            text: "Rent",
            href: "/properties",
            params: {
                type: "rent"
            }
        },
    ],
    contactText: "Contact us",
    languageOptions: [
        {
            text: "English",
            key: "en"
        },
        {
            text: "Spanish",
            key: "es"
        }
    ]
}