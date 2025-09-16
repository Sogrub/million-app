export interface FooterLocale {
    options: FooterOptionsLocale[];
    copyright: string;
    contactText: string;
}

export interface FooterOptionsLocale {
    text: string;
    href: string;
    params?: Record<string, string>;
}