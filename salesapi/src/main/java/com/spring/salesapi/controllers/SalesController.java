package com.spring.salesapi.controllers;
import com.spring.salesapi.models.Sales;
import com.spring.salesapi.repositories.SalesRepository;

import java.math.BigDecimal;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class SalesController {

    @Autowired
    SalesRepository salesRepository;

    @RequestMapping(method=RequestMethod.GET, value="/api/sales")
    public Iterable<Sales> sales() {
        return salesRepository.findAll();
    }

    @RequestMapping(method=RequestMethod.POST, value="/api/sales")
    public String save(@RequestBody Sales sales) {
        salesRepository.save(sales);

        return sales.getId();
    }

    @RequestMapping(method=RequestMethod.GET, value="/api/sales/{id}")
    public Sales show(@PathVariable String id) {
    	Optional<Sales> mysale = salesRepository.findById(id);
        if (mysale.isPresent())
        	return mysale.get();
    	else
    		return new Sales();
    }

   
    @RequestMapping(method=RequestMethod.PUT, value="/api/sales/{id}")
    public Sales update(@PathVariable String id, @RequestBody Sales sales) {
        Optional<Sales> mysale = salesRepository.findById(id);
        if (mysale.isPresent()) {
        	Sales sale = mysale.get();
	        if(sales.getPersonId() != null)
	        	sale.setPersonId(sales.getPersonId());
	        if(sales.getClientId() > 0)
	        	sale.setClientId(sales.getClientId());
	        if(sales.getInventoryId() > 0)
	        	sale.setInventoryId(sales.getInventoryId());
	        sale.setPrice(sales.getPrice());
	        sale.setDiscount(sales.getDiscount());
	        sale.setTax(sales.getTax());
	        if(sales.getQuantity() > 0)
	        	sale.setQuantity(sales.getQuantity());
	        if(sales.getCreated() != null)
	        	sale.setCreated(sales.getCreated());
	        if(sales.getUpdated() != null)
	        	sale.setUpdated(sales.getUpdated());	        
	        salesRepository.save(sale);
	        return sale;
        }
        else
        	return new Sales();
    }

    @RequestMapping(method=RequestMethod.DELETE, value="/api/sales/{id}")
    public String delete(@PathVariable String id) {
    	Optional<Sales> sales = salesRepository.findById(id);
    	if (sales.isPresent()) {
    		salesRepository.delete(sales.get());
    		return "sales deleted";
    	}
    	else
    		return "sale ID not found";
    }	
}
