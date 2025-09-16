// Components
import { Header } from "@/shared/components/header/header";
import { Hero } from "./components/hero/hero";
import { Benefits } from "./components/benefits/benefits";
import { Footer } from "@/shared/components/footer/footer";

const HomePage = () => {
  return (
    <div>
      <Header />
      <Hero />
      <Benefits />
      <Footer />
    </div>
  );
};

export default HomePage;