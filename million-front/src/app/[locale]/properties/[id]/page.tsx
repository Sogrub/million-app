"use client";
// Components
import { Footer } from "@/shared/components/footer/footer";
import { Header } from "@/shared/components/header/header";
import { Content } from "./components/content/content";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

const queryClient = new QueryClient();

const PropertyPage: React.FC = () => {
  return (
    <QueryClientProvider client={queryClient}>
      <Header />
      <Content />
      <Footer />
    </QueryClientProvider>
  );
};

export default PropertyPage;