export interface Properties {
  id: string;
  name: string;
  addressProperty: string;
  priceProperty: number;
  type: "sell" | "rent";
  owner: string;
  images: string[];
}

export interface Property {
  id: string;
  name: string;
  addressProperty: string;
  priceProperty: number;
  description: string;
  type: "sell" | "rent";
  owner: Owner;
  images: PropertyImage[];
}

export interface Owner {
  id: string;
  name: string;
  address: string;
  photo: string;
  birthDate: string;
}

export interface PropertyImage {
  id: string;
  propertyId: string;
  image: string;
  enabled: boolean;
}