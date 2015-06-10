SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `banco_estoque` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `banco_estoque` ;

-- -----------------------------------------------------
-- Table `banco_estoque`.`produtos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco_estoque`.`produtos` (
  `id_produtos` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `valor_compra` DECIMAL NOT NULL,
  `qtd` INT NOT NULL,
  `valor_venda` DECIMAL NOT NULL,
  PRIMARY KEY (`id_produtos`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `banco_estoque`.`caixa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco_estoque`.`caixa` (
  `id_caixa` INT NOT NULL AUTO_INCREMENT,
  `em_caixa` VARCHAR(45) NOT NULL,
  `nome` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_caixa`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `banco_estoque`.`entrada`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco_estoque`.`entrada` (
  `id_entrada` INT NOT NULL AUTO_INCREMENT,
  `data` DATETIME NOT NULL,
  `descricao` VARCHAR(45) NULL,
  `caixa_id_caixa` INT NOT NULL,
  `produtos_id_produtos` INT NOT NULL,
  `qtd` INT NOT NULL,
  PRIMARY KEY (`id_entrada`),
  INDEX `fk_entrada_caixa1_idx` (`caixa_id_caixa` ASC),
  INDEX `fk_entrada_produtos1_idx` (`produtos_id_produtos` ASC),
  CONSTRAINT `fk_entrada_caixa1`
    FOREIGN KEY (`caixa_id_caixa`)
    REFERENCES `banco_estoque`.`caixa` (`id_caixa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_entrada_produtos1`
    FOREIGN KEY (`produtos_id_produtos`)
    REFERENCES `banco_estoque`.`produtos` (`id_produtos`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `banco_estoque`.`saida`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco_estoque`.`saida` (
  `id_saida` INT NOT NULL AUTO_INCREMENT,
  `data` DATETIME NOT NULL,
  `descricao` VARCHAR(45) NULL,
  `caixa_id_caixa` INT NOT NULL,
  `produtos_id_produtos` INT NOT NULL,
  `qtd` INT NOT NULL,
  PRIMARY KEY (`id_saida`),
  INDEX `fk_saida_caixa1_idx` (`caixa_id_caixa` ASC),
  INDEX `fk_saida_produtos1_idx` (`produtos_id_produtos` ASC),
  CONSTRAINT `fk_saida_caixa1`
    FOREIGN KEY (`caixa_id_caixa`)
    REFERENCES `banco_estoque`.`caixa` (`id_caixa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_saida_produtos1`
    FOREIGN KEY (`produtos_id_produtos`)
    REFERENCES `banco_estoque`.`produtos` (`id_produtos`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `banco_estoque`.`usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `banco_estoque`.`usuario` (
  `id_usuario` INT NOT NULL AUTO_INCREMENT,
  `login` VARCHAR(45) NOT NULL,
  `senha` VARCHAR(45) NOT NULL,
  `nome_completo` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_usuario`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `banco_estoque`.`produtos`
-- -----------------------------------------------------
START TRANSACTION;
USE `banco_estoque`;
INSERT INTO `banco_estoque`.`produtos` (`id_produtos`, `nome`, `valor_compra`, `qtd`, `valor_venda`) VALUES (1, 'Banana', 10, 5, 20);

COMMIT;


-- -----------------------------------------------------
-- Data for table `banco_estoque`.`caixa`
-- -----------------------------------------------------
START TRANSACTION;
USE `banco_estoque`;
INSERT INTO `banco_estoque`.`caixa` (`id_caixa`, `em_caixa`, `nome`) VALUES (1, '0', 'banco do brasil');

COMMIT;


-- -----------------------------------------------------
-- Data for table `banco_estoque`.`usuario`
-- -----------------------------------------------------
START TRANSACTION;
USE `banco_estoque`;
INSERT INTO `banco_estoque`.`usuario` (`id_usuario`, `login`, `senha`, `nome_completo`) VALUES (1, 'otavio', '123', 'Otavio Schwanck');

COMMIT;

USE `banco_estoque`;

DELIMITER $$
USE `banco_estoque`$$
CREATE TRIGGER `entrada_AINS` AFTER INSERT ON `entrada` FOR EACH ROW
begin
		declare valor decimal;
		set valor = (select valor_venda from produtos where id_produtos = new.produtos_id_produtos limit 1);
		update caixa set em_caixa = em_caixa - (new.qtd * valor) where id_caixa = new.caixa_id_caixa;
		update produtos set qtd = qtd + new.qtd where id_produtos = new.produtos_id_produtos;
end $$

USE `banco_estoque`$$
CREATE TRIGGER `saida_AINS` AFTER INSERT ON `saida` FOR EACH ROW
	begin
		declare valor decimal;
		set valor = (select valor_venda from produtos where id_produtos = new.produtos_id_produtos limit 1);
		update caixa set em_caixa = em_caixa + (new.qtd * valor) where id_caixa = new.caixa_id_caixa;
		update produtos set qtd = qtd - new.qtd where id_produtos = new.produtos_id_produtos;
end $$


DELIMITER ;
