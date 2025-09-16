// Interfaces
import { FooterLocale } from "../interfaces/footer.interface";

export const FOOTER_LOCALE_ES: FooterLocale = {
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
  copyright: "Million Builder. Todos los derechos reservados.",
  contactText: "Contáctanos",
}

export const FOOTER_LOCALE_EN: FooterLocale = {
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
  copyright: "Million Builder. All rights reserved.",
  contactText: "Contact us",
}