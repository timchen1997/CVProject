   M S B A M L   `   `   `  ���� D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  #    CVProject.Dialog.ResizeDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:CVProject.Dialog     X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � Title$  Resize��$	��123��$	��300�����	#FF363636 � WindowStartupLocation$ CenterScreen=�.��� .+��� -    ��Name$ label��$��	New Width��$
��Left=�$��	10,13,0,0q�$	��Top=�%  Xceed.Wpf.Toolkit.DecimalUpDown  -   $��width��$
��Left=�$��	92,10,0,0q�$	��Top=�$��60���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�   Maximum$ 65535X��� -   $ 
label_Copy��$��
New Height��$
��Left=�$��	10,38,0,0q�$	��Top=�  -   $��height��$
��Left=�$��	92,35,0,0q�$	��Top=�$��60��$ 0X�$ 65535X��� -    ��Name$ 	btnCancel��$��Cancel��$
��Left=�$��
207,35,0,0q�$	��Top=�$��75���� -   $ btnOK��$��OK��$
��Left=�$��
207,10,0,0q�$	��Top=�$��75���� -   $ label_Copy1��$��Resize Mode��$
��Left=�$��	10,62,0,0q�$	��Top=��� -    ��Name$ cboxMode��$
��Left=�$��	88,60,0,0q�$	��Top=�$��60�� �� SelectedIndex$ 0��.@��� $��Nearest���� $��Linear��