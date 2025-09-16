"use client";
// Components
import { Footer } from "@/shared/components/footer/footer";
import { Header } from "@/shared/components/header/header";
import { PropertiesProvider } from "./context/properties.context";
import { Filters } from "./components/filters/filters";
import { Items } from "./components/items/items";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

const queryClient = new QueryClient();

const PropertiesPageContent: React.FC = () => {
  return (
    <QueryClientProvider client={queryClient}>
      <PropertiesProvider>
        <Header />
        <Filters />
        <Items />
        <Footer />
      </PropertiesProvider>
    </QueryClientProvider>
  );
};

export default PropertiesPageContent;