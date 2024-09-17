# ToDo Design Patterns API

Bu proje, çeşitli tasarım desenlerini (Design Patterns) kullanarak bir ToDo uygulaması oluşturmayı amaçlamaktadır. Projede Decorator ve Command patternleri uygulanmıştır.

## İçindekiler

- [Kurulum](#kurulum)
- [Kullanım](#kullanım)
- [Tasarım Desenleri](#tasarım-desenleri)
    - [Decorator Pattern](#decorator-pattern)
    - [Command Pattern](#command-pattern)
- [Katkıda Bulunma](#katkıda-bulunma)
- [Lisans](#lisans)

## Kurulum

Projeyi klonlayın:

```bash
https://github.com/nepnesomao/ToDoDesignPatternsAPI.git
cd ToDoDesignPatternsAPI
```
Gerekli bağımlılıkları yükleyin:

```bash
dotnet restore
```
Projeyi çalıştırın:

```bash
dotnet run
```
### Kullanım
Proje, çeşitli tasarım desenlerini kullanarak ToDo görevlerini yönetmenizi sağlar. Aşağıda bazı örnek kullanım senaryoları verilmiştir:

1. **ToDo Görevi Ekleme**
```bash
curl -X POST -H "Content-Type: application/json" -d '{"title": "Yeni Görev", "description": "Yeni görev açıklaması"}' http://localhost:5000/api/todo
```
2. **ToDo Görevlerini Listeleme**
```bash
curl http://localhost:5000/api/todo
```
3. **ToDo Görevi Tamamlama**
```bash
curl -X PUT http://localhost:5000/api/todo/1/complete
```

## Tasarım Desenleri

### Decorator Pattern
Decorator pattern, bir nesnenin davranışını dinamik olarak değiştirmek için kullanılır. Bu projede, TodoTask nesnesine ek özellikler eklemek için kullanılmıştır.

### Command Pattern
Command pattern, bir işlemi nesne olarak kapsülleyerek, işlemleri parametreleştirme, sıraya koyma ve geri alma gibi işlemleri kolaylaştırır. Bu projede, görevleri yönetmek için kullanılmıştır.

## Katkıda Bulunma
Katkıda bulunmak isterseniz, lütfen bir pull request gönderin. Her türlü katkı değerlidir.

## Lisans
Bu proje MIT lisansı ile lisanslanmıştır. Daha fazla bilgi için [MIT](https://choosealicense.com/licenses/mit/) lisansına bakabilirsiniz.
```

